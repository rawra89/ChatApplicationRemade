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

namespace ChatApplicationRemade.src;

using ClientSocket = Socket;
public partial class JoinMenu : Form
{
	ClientSocket clientSocket;
	public JoinMenu()
	{
		InitializeComponent();
	}

	private void button1_Click( object sender, EventArgs e )
	{
		if ( String.IsNullOrEmpty( textBox1.Text ) )
		{
			MessageBox.Show( "Please enter an IP Address!", "Error", MessageBoxButtons.OK );
			return;
		}

		IPAddress? IPAddr = null;
		if ( !IPAddress.TryParse( textBox1.Text, out IPAddr ) )
		{
			MessageBox.Show( "Please enter a valid IP Address!", "Error", MessageBoxButtons.OK );
		}

		Thread join = new Thread( () => { AttemptToJoinChatroom( IPAddr ); } );
		join.Start();
	}

	private void AttemptToJoinChatroom( IPAddress ipaddr )
	{
		byte attempts = 5; // attempts;
		try
		{
			var endpoint = new IPEndPoint( ipaddr, 0 );
			clientSocket = new ClientSocket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
			do
			{
				// Attempt to establish a connection to the IP address entered.
				clientSocket.Connect( ipaddr, 0 );

			} while ( attempts-- > 0 );
		}

		catch
		{
			MessageBox.Show( "Failed to find the chatroom!", "Error", MessageBoxButtons.OK );
			clientSocket.Close();
		}

		JoinSuccess();
	}

	private void SendUserInfo()
	{
		byte attempts = 5; // attempts;
		try
		{
			do
			{
				


			} while ( attempts-- > 0 );
		}
		catch
		{
			MessageBox.Show( "Failed to send user info. You have been disconnected", "Error", MessageBoxButtons.OK );
			clientSocket.Close();
		}
	}

	private bool WaitForServerACKMessage()
	{


		return false;
	}

	private void JoinSuccess()
	{
		// Join
		SendUserInfo();
		// Wait for server to accept


		ChatroomForm chatroom = new ChatroomForm();
	}

}