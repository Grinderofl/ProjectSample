namespace ProjectSample.Areas.Basket.Commands
{
    public class RemoveProductFromBasketCommand
    {
        public RemoveProductFromBasketCommand(long id)
        {
            Id = id;
        }

        public long Id { get; }
    }
}