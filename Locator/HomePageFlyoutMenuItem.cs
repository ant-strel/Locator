namespace Locator
{

    public class HomePageFlyoutMenuItem
    {
        public HomePageFlyoutMenuItem()
        {
            TargetType = typeof(HomePageFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}