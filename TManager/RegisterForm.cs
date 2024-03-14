using TManager.business;
using TManager.entity;
using TManager.error;
using TManager.repository;
using TManager.service;

namespace TManager
{
    public partial class RegisterForm : Form
    {
        private UserBusiness userBusiness;
        public User Response { get; set; }
        public RegisterForm()
        {
            userBusiness = new UserBusiness(new UserServiceImpl(new UserRepository()));
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Response = userBusiness.registerUser(usernameTextBox.Text, passwordTextBox.Text, repeatPasswordTextBox.Text);
                this.DialogResult = DialogResult.OK;
            }
            catch (InvalidUsernameException ex)
            {
                MessageBox.Show(ErrorConst.INVALID_USERNAME_ERROR_MESSAGE, ErrorConst.INVALID_USERNAME_ERROR_CODE,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidPasswordException ex)
            {
                MessageBox.Show(ErrorConst.INVALID_PASSWORD_ERROR_MESSAGE, ErrorConst.INVALID_PASSWORD_ERROR_CODE,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (PasswordNotMatchException ex)
            {
                MessageBox.Show(ErrorConst.PASSWORD_NOT_MATCH_ERROR_MESSAGE, ErrorConst.PASSWORD_NOT_MATCH_ERROR_CODE,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DuplicateUserException ex)
            {
                MessageBox.Show(ErrorConst.DUPLICATE_USER_ERROR_MESSAGE, ErrorConst.DUPLICATE_USER_ERROR_CODE,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
