namespace Diet.Models;

public partial class Food : FoodBase
{
    public required string Name { get; set; }

    public long MaxDailyPortion { get; set; }
}
