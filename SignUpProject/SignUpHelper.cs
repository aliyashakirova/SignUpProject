using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SignUpProject
{
    public class SignUpHelper
    {
        public static bool LoginCredintialsVerification(string login, string password, string confirmPassword)
        {
            var IsLoginOK = LoginVerification(login);

            var IsPswOK = PasswordVerification(password, confirmPassword);

            if (IsLoginOK & IsPswOK ) { return true; }
            return false;
        }

        private static bool PasswordVerification(string password, string confirmPassword)
        {
            try
            {
                char[] pswch = password.ToCharArray();
                int pswLength = pswch.Length;
                bool a = false;

                if (pswLength < 20)
                {
                    for (int i = 0; i < pswLength; i++)
                    {
                        if (char.IsWhiteSpace(pswch[i]))
                        {
                            throw new WrongPasswordException("Password contains whitespace.");
                        }
                    }
                    for (int i = 0; i < pswLength; i++)
                    {
                        if (char.IsDigit(pswch[i]))
                        {
                            a = true;
                            break;
                        }
                    }
                    if (!a)
                    {
                        throw new WrongPasswordException("Password should contain at least 1 digit");
                    }
                    if (password != confirmPassword)
                    {
                        throw new WrongPasswordException("Password and Confirm Password must match");
                    }
                    return true;
                }
                else
                {
                    throw new WrongPasswordException("Password length is more than 20 characters");
                }
            }
            catch (WrongPasswordException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private static bool LoginVerification(string login)
        {
            try
            {
                //bool b = true;
                char[] logch = login.ToCharArray();
                int loginLength = logch.Length;
                if (loginLength < 20)
                {
                    for (int i = 0; i < loginLength; i++)
                    {
                        if (char.IsWhiteSpace(logch[i]))
                        {
                            throw new WrongLoginException("Login contains whitespace.");
                        }
                    }
                    return true;
                }
                else
                {
                    throw new WrongLoginException("Login length is more than 20 characters");
                }
            }
            catch (WrongLoginException ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        class WrongLoginException : Exception
        {
            public WrongLoginException()
            {
            }

            public WrongLoginException(string message) : base(message)
            {
            }

        }
    }

    class WrongPasswordException : Exception
    {
        public WrongPasswordException()
        {
        }

        public WrongPasswordException(string message) : base(message)
        {
        }
    }
}
