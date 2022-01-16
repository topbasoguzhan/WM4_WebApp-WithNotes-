namespace ItServiceApp.ViewModels
{
    public class ProfileUpdateViewModel
    {
        public UserProfileViewModel UserProfileViewModel { get; set; } = new();

        public PasswordUpdateViewModel passwordUpdateViewModel { get; set; } = new();

        //tek bir  sayfada birkaç sayfa açılmasını böyle sağlarız sayfa değiştirmeden.

    }
}
