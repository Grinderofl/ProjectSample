namespace ProjectSample.Areas.Basket.Commands
{
    public class AddProductToBasketCommand
    {
        public AddProductToBasketCommand(long id)
        {
            Id = id;
        }

        public long Id { get; }
    }
}