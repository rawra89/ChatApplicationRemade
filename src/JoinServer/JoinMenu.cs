using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Logging;
using SharedFunctions;

namespace ChatApplicationRemade.src;
using ClientSocket = Socket;
public partial class JoinMenu : Form
{
	ClientSocket clientSocket;

	public JoinMenu()
	{
		InitializeComponent();
	}

	private void button_Join_Click( object sender, EventArgs e )
	{
		if ( String.IsNullOrEmpty( textBox_IPAddress.Text ) )
		{
			MessageBox.Show( "Please enter an IP Address!", "Error", MessageBoxButtons.OK );
			return;
		}

		IPAddress? IPAddr = null;
		if ( !IPAddress.TryParse( textBox_IPAddress.Text, out IPAddr ) )
		{
			MessageBox.Show( "Please enter a valid IP Address!", "Error", MessageBoxButtons.OK );
			return;
		}

		Thread th = new Thread( () => { AttemptToJoinChatroom( IPAddr ); } );
		th.Start();
	}

	private void AttemptToJoinChatroom( IPAddress ipaddr )
	{
		try
		{
			var endpoint = new IPEndPoint( ipaddr, 0 );
			clientSocket = new ClientSocket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
			// Attempt to establish a connection to the IP address entered.
			clientSocket.Connect( ipaddr, 0 );
		}

		catch
		{
			MessageBox.Show( "Failed to find chatroom.", "Error", MessageBoxButtons.OK );
			clientSocket.Close();
			return;
		}

		JoinSuccess();
	}

	private bool SendUserInfo()
	{
		try
		{
			// Send name and ID...
			Shared.SendMessage( ref clientSocket, new MessageState( "name", "190308", Shared.USERINFOMSG ), 512 );

			return WaitForServerACKMessage();
		}
		catch ( SocketException e ) 
		{
			MessageBox.Show( e.Message, "Error", MessageBoxButtons.OK );
		}

		return false;
	}

	private bool WaitForServerACKMessage()
	{
		if ( !clientSocket.Connected || clientSocket == null )
			return false;

		byte[] buf = new byte[64];
		clientSocket.Receive( buf );

		return Encoding.UTF8.GetString( buf ).Equals( Shared.ACKMSG );
	}

	private ServerInfo? ReceiveServerInfo()
	{
		MessageState? msg = Shared.ReceiveMessage( ref clientSocket, 1024 );

		if ( msg == null )
			return null;

		// Receive in the order of the ServerInfo class

		



		return null;
	}

	private void JoinSuccess()
	{
		// Send the info.
		SendUserInfo();
		// Wait for server to accept...
		WaitForServerACKMessage();

		// Receive server info.
		ServerInfo? svInf = ReceiveServerInfo();

		if ( svInf == null )
		{
			MessageBox.Show( "Unable to receive server info! Disconnected.", "Error", MessageBoxButtons.OK );
			clientSocket.Close();
			return;
		}

		// Start opening up the chat room box.
		ChatroomForm chatroom = new ChatroomForm( ref clientSocket, ref svInf );
		chatroom.ShowDialog();
	}
}