using TManager.business;
using TManager.entity;
using TManager.error;
using TManager.repository;
using TManager.service;

namespace TManager
{
    public partial class LogInForm : Form
    {
        private UserBusiness UserBusiness;
        public User Response { get; set; }
        private User? CurrentLoggedInUser;
        public LogInForm(User? currentLoggedInUser)
        {
            UserBusiness = new UserBusiness(new UserServiceImpl(new UserRepository()));
            CurrentLoggedInUser = currentLoggedInUser;
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Response = UserBusiness.logIn(usernameTextBox.Text, passwordTextBox.Text, CurrentLoggedInUser);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (InvalidUsernameException)
            {
                MessageBox.Show(ErrorConst.INVALID_USERNAME_ERROR_MESSAGE, ErrorConst.INVALID_USERNAME_ERROR_CODE,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (AlreadyLoggedInUserException)
            {
                MessageBox.Show(ErrorConst.ALREADY_LOGGED_IN_USER_ERROR_MESSAGE, ErrorConst.ALREADY_LOGGED_IN_USER_ERROR_CODE,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UserNotFoundException)
            {
                MessageBox.Show(ErrorConst.USER_NOT_FOUND_ERROR_MESSAGE, ErrorConst.USER_NOT_FOUND_ERROR_CODE,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IncorrectPasswordException)
            {
                MessageBox.Show(ErrorConst.INCORRECT_PASSWORD_ERROR_MESSAGE, ErrorConst.INCORRECT_PASSWORD_ERROR_CODE,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void registerLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            DialogResult result = registerForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                Visible = false;
                Response = registerForm.Response;
                DialogResult = registerForm.DialogResult;
                return;
            }
            else
            {
                Visible = true;
            }
        }
    }
}
