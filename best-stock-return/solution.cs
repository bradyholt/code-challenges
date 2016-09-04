public StockTransaction DetermineMaxProfit(List<int> dailyPrices) {

    int bestBuyPrice = 0;
    int bestSellPrice = 0;
    int maxProfit = 0;
    int lowestBuyPrice = null;

    foreach(int sellPrice in dailyPrices) {
        
        if (lowestBuyPrice == null) {
            lowestBuyPrice = sellPrice;
            continue;
        } else if (sellPrice < lowestBuyPrice) {
            lowestBuyPrice = sellPrice;;
        }

        int currentBestProfit = (sellPrice - lowestBuyPrice);
        if (currentBestProfit > maxProfit){
            bestBuyPrice = buyPrice;
            bestSellPrice = sellPrice;
            maxProfit = currentProfit;
        }
    }

    StockTransaction maxProfitTransaction = new StockTransaction();
    maxProfitTransaction.BuyPrice = bestBuyPrice;
    maxProfitTransaction.SellPrice = bestSellPrice;

    return maxProfitTransaction;
}

public class StockTransaction {
    public int BuyPrice { set; get; }
    public int SellPrice {set; get; }

    public int Profit {
        get {
            return (sellPrice - buyPrice);
        }
    }
}

