namespace MasterMind.Resources
{
    /// <summary>
    /// Contains texts used in every type of Mastermind application.
    /// </summary>
    public static class Texts
    {
        /// <summary>
        /// Text displayed when the user wants to check the game rules.
        /// </summary>
        public static string GameRules { get; } = "\nPierwszy gracz ustala kod (sekretny) składający się z 4 kolorów -kolejność ma znaczenie, kolory mogą się powtarzać. \n1) Podaje swoją kombinację 4 kolorów w odpowiedniej kolejności \na. Pierwszy gracz weryfikuje propozycję i odpowiada, podając liczbę trafień dokładnych (tzn. właściwy kolor na właściwej pozycji - odpowiednia liczba kółek czarnych) oraz trafień niedokładnych (tzn. właściwy kolor na niewłaściwej pozycji - odpowiednia liczba kółek białych) \nb. Kroki powyższe powtarzane są wielokrotnie \nc. Drugi gracz próbuje odgadnąć sekretny kod:\n2) Gra kończy się, gdy drugi gracz odgadnie sekretny kod\n3) Dobry gracz po 4-5 próbach potrafi odgadnąć sekretny kod (w zależności od stosowanej strategii - strategia bazuje na dobrym początku i odpowiednim wnioskowaniu w dalszych krokach)";
    }
}
