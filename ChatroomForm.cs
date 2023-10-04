
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharedFunctions;

namespace ChatApplicationRemade;

public partial class ChatroomForm : Form
{
	readonly Socket socket;
	readonly ServerInfo? serverInfo;

	public ChatroomForm( ref Socket _clientSocket, ref ServerInfo? _serverInfo )
	{
		InitializeComponent();
		socket = _clientSocket;
		serverInfo = _serverInfo;
	}

	
}
