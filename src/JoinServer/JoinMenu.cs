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
	IPAddress ipaddr;
	public JoinMenu()
	{
		InitializeComponent();
	}

    private void button_Join_Click_1( object sender, EventArgs e )
    {
        if ( String.IsNullOrEmpty( textBox_IPAddress.Text ) )
        {
            MessageBox.Show( "Please enter an IP Address!", "Error", MessageBoxButtons.OK );
            return;
        }

		ipaddr = IPAddress.Parse("127.0.0.1");

        if ( !IPAddress.TryParse( textBox_IPAddress.Text, out ipaddr ) )
        {
            MessageBox.Show( "Please enter a valid IP Address!", "Error", MessageBoxButtons.OK );
            return;
        }

		BGW_ChatroomJoiner.RunWorkerAsync();
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
			MessageBox.Show( "Failed to find the chatroom.", "Error", MessageBoxButtons.OK );
			clientSocket.Close();
			return;
		}

		JoinSuccess();
	}

	private async Task<bool> SendUserInfo()
	{
		try
		{
			// Send name and ID...
			await Shared.SendMessage( clientSocket, new MessageState( "name", "190308", Shared.USERINFOMSG ), 512 );

			return WaitForServerACKMessage();
		}
		catch ( SocketException e ) 
		{
			MessageBox.Show( e.Message, "Unable to send user information to the server!", MessageBoxButtons.OK );
		}

		return false;
	}

	private bool WaitForServerACKMessage()
	{
		if ( !clientSocket.Connected || clientSocket == null )
			return false;

		byte[] buf = new byte[16];
		clientSocket.Receive( buf );

		return Encoding.UTF8.GetString( buf ).Equals( Shared.ACKMSG );
	}

	private  ServerInfo? ReceiveServerInfo()
	{
		Task<MessageState?> msg = Shared.ReceiveMessage( clientSocket, 1024 );

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

	private void BGW_ChatroomJoiner_DoWork( object sender, DoWorkEventArgs e )
	{
        // Connecting Window pops up...
        AttemptToJoinChatroom( ipaddr );
    }
}