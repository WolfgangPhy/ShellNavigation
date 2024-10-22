namespace ShellNavigation;

public partial class LoginPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        try
        {
            await Shell.Current.GoToAsync($"///{nameof(FirstTab)}");
            /*
               * - Si pas de Route dans le balise ShellContent et pas de RegisterRoute dans le codeBehind :
               *
               *    - Pour FirstTab, /FirstTab, //FirstTab, ///FirstTab :
               *
               * System.ArgumentException
               * Message=
               * unable to figure out route for: FirstTab (Parameter 'uri')
               *
               * #####################################
               *
               * - Si pas de Route dans le balise ShellContent mais RegisterRoute dans le codeBehind :
               *
               *    - Pour FirstTab, /FirstTab
               *
               * Fonctionne mais pas de TabBar
               *
               *    - Pour //FirstTab :
               *
               * System.Exception
               * Message=
               * Global routes currently cannot be the only page on the stack, so absolute routing to global routes is not supported.
               * For now, just navigate to: FirstTab
               *
               *   - Pour ///FirstTab :
               * System.Exception
               * Message=
               * Global routes currently cannot be the only page on the stack, so absolute routing to global routes is not supported.
               * For now, just navigate to: /FirstTab
               *
               *
               * #####################################
               *
               * - Si Route dans le balise ShellContent et pas de RegisterRoute dans le codeBehind :
               *
               *   - Pour FirstTab :
               *
               * System.Exception
               * Message=
               * Relative routing to shell elements is currently not supported. Try prefixing your uri with ///: ///FirstTab
               *
               *   - Pour /FirstTab :
               * System.Exception
               * Message=
               * Relative routing to shell elements is currently not supported. Try prefixing your uri with ///: ////FirstTab
               *
               *   - Pour //FirstTab et ///FirstTab
               *
               * Fonctionne
               *
               * #####################################
               *
               * - Si Route dans le balise ShellContent et RegisterRoute dans le codeBehind :
               *
               *   - Pour FirstTab et /FirstTab :
               *
               * Fonctionne mais pas de TabBar
               *
               *   - Pour //FirstTab et ///FirstTab :
               *
               * Fonctionne 
               */
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
    }
}