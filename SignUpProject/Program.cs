using SignUpProject;

string login = Console.ReadLine();
string password = Console.ReadLine();
string confirmPassword = Console.ReadLine();

var areLoginCredentialsOK = SignUpHelper.LoginCredintialsVerification(login, password, confirmPassword);


if (areLoginCredentialsOK)
    Console.WriteLine("Credentials are ok");
else
    Console.WriteLine("Credentials are not ok");
