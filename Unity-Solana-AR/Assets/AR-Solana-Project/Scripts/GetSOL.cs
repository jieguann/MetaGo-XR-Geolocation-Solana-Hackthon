using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AllArt.Solana.Example;
using TMPro;
public class GetSOL : MonoBehaviour
{
    public TMP_Text solText;
    // Start is called before the first frame update

    
    // Update is called once per frame
    

    public async void UpdateWalletBalanceDisplay()
    {
        if (SimpleWallet.instance.wallet is null) return;

        double sol = await SimpleWallet.instance.GetSolAmmount(SimpleWallet.instance.wallet.GetAccount(0));
        MainThreadDispatcher.Instance().Enqueue(() => { solText.text = "SOL: "+ $"{sol}"; });
    }
}
