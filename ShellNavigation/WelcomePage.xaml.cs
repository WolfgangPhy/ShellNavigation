namespace ShellNavigation;

public partial class WelcomePage
{
	public WelcomePage()
	{
		InitializeComponent();
	}

    private async void Button_OnClicked(object? sender, EventArgs e)
    {
        try
        {
            await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
            /*
             * - Si pas de Route dans le balise ShellContent et pas de RegisterRoute dans le codeBehind :
             *
             *    - Pour LoginPage, /LoginPage, //LoginPage, ///LoginPage :
             *
             * System.ArgumentException
             * Message=
             * unable to figure out route for: LoginPage (Parameter 'uri')
             *
             * #####################################
             *
             * - Si pas de Route dans le balise ShellContent mais RegisterRoute dans le codeBehind :
             *
             *    - Pour LoginPage, /LoginPage
             *
             * Fonctionne
             *
             *    - Pour //LoginPage :
             *
             * System.Exception
             * Message=
             * Global routes currently cannot be the only page on the stack, so absolute routing to global routes is not supported.
             * For now, just navigate to: LoginPage
             *
             *   - Pour ///LoginPage :
             * System.Exception
             * Message=
             * Global routes currently cannot be the only page on the stack, so absolute routing to global routes is not supported.
             * For now, just navigate to: /LoginPage
             *
             *
             * #####################################
             *
             * - Si Route dans le balise ShellContent et pas de RegisterRoute dans le codeBehind :
             *
             *   - Pour LoginPage :
             *
             * System.Exception
             * Message=
             * Relative routing to shell elements is currently not supported. Try prefixing your uri with ///: ///LoginPage
             *
             *   - Pour /LoginPage :
             * System.Exception
             * Message=
             * Relative routing to shell elements is currently not supported. Try prefixing your uri with ///: ////LoginPage
             *
             *   - Pour //LoginPage et ///LoginPage
             *
             * Fonctionne
             *
             * #####################################
             *
             * - Si Route dans le balise ShellContent et RegisterRoute dans le codeBehind :
             *
             *   - Pour LoginPage et /LoginPage :
             *
             * Fonctionne avec annimation "Classique" (qui arrive de la droite)
             *
             *   - Pour //LoginPage et ///LoginPage :
             *
             * Fonctionne avec annimation "Popup"
             */
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
    }
}