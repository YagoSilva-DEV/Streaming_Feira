using Streamall.Models.Enums;
using Streamall.Exceptions;

namespace Streamall.Models.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserType UserType { get; set; }

        public User(string userName, string password, string email)
        {
            //Construtor para validação de login
            if (string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(password) && string.IsNullOrEmpty(email))
                throw new InvalidLoginException("Os campos de login estão vazios");
            if (string.IsNullOrWhiteSpace(userName))
                throw new InvalidLoginException("Insira o nome de usuário");
            if (string.IsNullOrWhiteSpace(email))
                throw new InvalidLoginException("Insira o email");
            VerifyEmail(email);
            if (string.IsNullOrWhiteSpace(password))
                throw new InvalidLoginException("Insira a senha");

            UserName = userName;
            Password = password;
            Email = email;
        }

        public User(string fullName, string userName, string password, string email)
        {
            //Construtor para validação de cadastro
            if (string.IsNullOrEmpty(fullName) && string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(password) && string.IsNullOrEmpty(email))
                throw new InvalidSignUpException("Os campos de cadastro estão vazios");
            if (string.IsNullOrWhiteSpace(fullName))
                throw new InvalidSignUpException("Insira o nome completo");
            if (string.IsNullOrWhiteSpace(userName))
                throw new InvalidSignUpException("Insira o nome de usuário");
            if (string.IsNullOrWhiteSpace(email))
                throw new InvalidSignUpException("Insira o email");
            VerifyEmail(email);

            if (string.IsNullOrWhiteSpace(password))
                throw new InvalidSignUpException("Insira a senha");
            VerifyPassword(password);


            FullName = fullName;
            UserName = userName;
            Password = password;
            Email = email;
        }

        public User(int userId, string fullName, string userName, string password, string email, UserType userType)
        {
            UserId = userId;
            FullName = fullName;
            UserName = userName;
            Password = password;
            Email = email;
            UserType = userType;
        }

        private void VerifyEmail(string email)
        {
            bool hasSign = false;
            bool hasDot = false;
            foreach(char ch in email)
            {
                if(ch == '@')
                    hasSign = true;
                if(ch == '.')
                    hasDot = true;
            }

            if (!(hasSign && hasDot))
                throw new InvalidEmailException("O endereço email está incorreto");
        }

        private void VerifyPassword(string password)
        {
            if (password.Length <= 8 || string.IsNullOrEmpty(password))
                throw new InvalidPasswordException("Senha deve conter mais que 8 caracteres");

            bool hasUpperCase = false;
            bool hasLowerCase = false;
            bool hasNumber = false;
            foreach (char ch in password)
            {
                if (char.IsUpper(ch))
                    hasUpperCase = true;
                if (char.IsLower(ch))
                    hasLowerCase = true;
                if (char.IsNumber(ch))
                    hasNumber = true;
            }

            if (!(hasUpperCase && hasLowerCase && hasNumber))
                throw new InvalidPasswordException("Use maiúscula, minúscula e número.");
        }
    }
}
