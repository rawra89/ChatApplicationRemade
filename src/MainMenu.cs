using ChatApplicationRemade.src;

namespace ChatApplicationRemade;
public partial class MainMenu : Form
{
	public MainMenu()
	{
		InitializeComponent();
	}

	private void MainMenu_Load(object sender, EventArgs e)
	{
		// On load, ask for name.
		// 
	}

	private void button_Create_Click(object sender, EventArgs e)
	{
		// Create a room, start a form up for it
		var CreateRoomForm = new CreateForm();
		CreateRoomForm.ShowDialog();
	}

	private void button_Join_Click(object sender, EventArgs e)
	{
		// Join a room, get a join room form up.
		var JoinRoomForm = new JoinMenu();
		JoinRoomForm.ShowDialog();
	}
}
