using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplicationRemade;

public static class Shared
{
	public const string BREAKMSG = "|<BREAKMSG>|";
	public const string ENDMSG = "|<ENDMSG>|";

	// Send out messages with breaks.
	[Serializable]
	public struct MessageState
	{
		public string name;
		public string ID;
		public string message;

		public MessageState( string _name, string _ID, string _message )
		{
			name = _name + BREAKMSG;
			ID = _ID + BREAKMSG;
			message = _message + BREAKMSG;
		}

		public override string ToString()
		{
			return name + ID + message;
		}
	}

	public static int SendMessage( ref Socket socket, MessageState msg, int buffersize )
	{
		if ( socket == null || !socket.Connected )
			return -1;

		byte[] bytes = new byte[buffersize];

		bytes = Encoding.UTF8.GetBytes( msg.ToString() );

		return socket.Send( bytes );
	}

	public static string ReceiveMessage( ref Socket socket, int buffersize )
	{
		// Receive the MessageState as a whole string
		if ( socket == null || !socket.Connected )
			return "";

		byte[] buf = new byte[ buffersize ];
		string msg = "";

		while ( socket.Receive( buf ) > 0 )
		{
			msg += Encoding.UTF8.GetString( buf );
		}

		return msg;
	}
}
