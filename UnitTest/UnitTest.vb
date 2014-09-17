Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class UnitTest

    <TestMethod()> Public Sub TestRomanizeVB()
        Assert.AreEqual(RomanizeVB.Romanize.RomanizeText("Γιώργος Σχίζας"), "Giorgos Schizas")
        Assert.AreEqual(RomanizeVB.Romanize.RomanizeText("Θανάσης ΘΑΝΑΣΗΣ θΑνάσης ΘΑνάσης"), "Thanasis THANASIS thAnasis THAnasis")
        Assert.AreEqual(RomanizeVB.Romanize.RomanizeText("Αντώνης Ψαράς με ψάρια"), "Antonis Psaras me psaria")
        Assert.AreEqual(RomanizeVB.Romanize.RomanizeText("Αυγά αύριο παύση"), "Avga avrio pafsi")
        Assert.AreEqual(RomanizeVB.Romanize.RomanizeText("Άγγελος αρχάγγελος"), "Angelos archangelos")
        Assert.AreEqual(RomanizeVB.Romanize.RomanizeText("Ξάδελφος εξ αγχιστείας"), "Xadelfos ex anchisteias")
        Assert.AreEqual(RomanizeVB.Romanize.RomanizeText("Ακούμπα κάτω τα μπαούλα Γιακούμπ"), "Akoumpa kato ta baoula Giakoub")
        Assert.AreEqual(RomanizeVB.Romanize.RomanizeText("Ζεύξη Ρίου-Αντιρρίου"), "Zefxi Riou-Antirriou")
        Assert.AreEqual(RomanizeVB.Romanize.RomanizeText("μεταγραφή"), "metagrafi")
        Assert.AreEqual(RomanizeVB.Romanize.RomanizeText("Ούτε το αγγούρι ούτε η αγκινάρα γράφονται με γξ"), "Oute to angouri oute i agkinara grafontai me nx")
        Assert.AreEqual(RomanizeVB.Romanize.RomanizeText("ΟΥΡΑΝΟΣ Ουρανός ουρανός οϋρανός"), "OURANOS Ouranos ouranos oyranos")
        Assert.AreEqual(RomanizeVB.Romanize.RomanizeText("Έχω ελέγξει το 100% της μεθόδου"), "Echo elenxei to 100% tis methodou")
    End Sub

    <TestMethod()> Public Sub TestRomanizeCS()
        Assert.AreEqual(RomanizeCS.Romanize.RomanizeText("Γιώργος Σχίζας"), "Giorgos Schizas")
        Assert.AreEqual(RomanizeCS.Romanize.RomanizeText("Θανάσης ΘΑΝΑΣΗΣ θΑνάσης ΘΑνάσης"), "Thanasis THANASIS thAnasis THAnasis")
        Assert.AreEqual(RomanizeCS.Romanize.RomanizeText("Αντώνης Ψαράς με ψάρια"), "Antonis Psaras me psaria")
        Assert.AreEqual(RomanizeCS.Romanize.RomanizeText("Αυγά αύριο παύση"), "Avga avrio pafsi")
        Assert.AreEqual(RomanizeCS.Romanize.RomanizeText("Άγγελος αρχάγγελος"), "Angelos archangelos")
        Assert.AreEqual(RomanizeCS.Romanize.RomanizeText("Ξάδελφος εξ αγχιστείας"), "Xadelfos ex anchisteias")
        Assert.AreEqual(RomanizeCS.Romanize.RomanizeText("Ακούμπα κάτω τα μπαούλα Γιακούμπ"), "Akoumpa kato ta baoula Giakoub")
        Assert.AreEqual(RomanizeCS.Romanize.RomanizeText("Ζεύξη Ρίου-Αντιρρίου"), "Zefxi Riou-Antirriou")
        Assert.AreEqual(RomanizeCS.Romanize.RomanizeText("μεταγραφή"), "metagrafi")
        Assert.AreEqual(RomanizeCS.Romanize.RomanizeText("Ούτε το αγγούρι ούτε η αγκινάρα γράφονται με γξ"), "Oute to angouri oute i agkinara grafontai me nx")
        Assert.AreEqual(RomanizeCS.Romanize.RomanizeText("ΟΥΡΑΝΟΣ Ουρανός ουρανός οϋρανός"), "OURANOS Ouranos ouranos oyranos")
        Assert.AreEqual(RomanizeCS.Romanize.RomanizeText("Έχω ελέγξει το 100% της μεθόδου"), "Echo elenxei to 100% tis methodou")
    End Sub

End Class