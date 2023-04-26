#region Main Chess Programm
void MainProgramm()

{
   for (int i = 0; i < args.Length; i++)
   {
      string WhichField = args[i].Substring(1, 2);
      if (!char.IsUpper(args[i][0]) && args[i] != "e.p.")
      {
         args[i] = $"P{args[i]}";


      }
      string output = "";
      bool FileLineIntergrated = false;
      string WhichPiece = args[i].Substring(0, 1);
      string Captured = args[i].Substring(2, 1);
      string WhichFile = args[i].Substring(1, 1);
      System.Console.WriteLine(PieceCalculation(WhichPiece, output, WhichField, i, Captured, WhichFile, FileLineIntergrated));
   }

}
MainProgramm();
#endregion
#region Piece Calculation
string PieceCalculation(string WhichPiece, string output, string WhichField, int i, string Captured, string WhichFile, bool FileLineIntergrated)
{
   if (args[i] == "0-0")
   {
      return "King is  castling on the King side";
     
   }
   else if (args[i] == "0-0-0")
   {
      return "Queen is  castling on the Queen side";
      
   }
   else{
   switch (WhichPiece)
   {
      case "K":
         output += $"King";
         output += WhichPiecetoCaptured(Captured, output, WhichField, i, WhichPiece, WhichFile);
         break;
      case "Q":
         output += $"Queen";
         output += WhichPiecetoCaptured(Captured, output, WhichField, i, WhichPiece, WhichFile);
         break;
      case "B":
         output += $"Bishop";
         output += WhichPiecetoCaptured(Captured, output, WhichField, i, WhichPiece, WhichFile);
         break;
      case "N":
         output += $"Knight";
         output += WhichPiecetoCaptured(Captured, output, WhichField, i, WhichPiece, WhichFile);
         break;
      case "R":
         output += $"Rook";
         output += WhichPiecetoCaptured(Captured, output, WhichField, i, WhichPiece, WhichFile);
         break;
      case "P":
         output += $"Pawn";
         output += WhichPiecetoCaptured(Captured, output, WhichField, i, WhichPiece, WhichFile);
         break;

   }
   return output;}
}
#endregion
string WhichPiecetoCaptured(string Captured, string output, string WhichField, int i, string WhichPiece, string WhichFile)
{
   string FileLine = WhichFilethePieceisOn(WhichFile, output, WhichField, i, WhichPiece);
   string Promotion = CheckForQuennPromotion(WhichPiece, i, WhichField);
   if (args[i][0] == 'P' && Captured == "x" && args[i - 1] == "e.p.")
   {
      return $" {FileLine} captures the piece en passant and goes to {args[i].Substring(3, 2)}";
   }
   else if (Captured == "x")
   {
      return $" {FileLine} captures the piece on {args[i].Substring(3, 2)}";
   }
   else
   {
      return $" {FileLine} moves to {args[i].Substring(2, 2)} {Promotion}";
   }


}
string WhichFilethePieceisOn(string WhichFile, string output, string WhichField, int i, string WhichPiece)
{
   if (!char.IsDigit(args[i][2]))
   {
      if (char.IsDigit(args[i][1]))
      {
         return $" on {args[i].Substring(1, 1)}-rank";
      }
      else
      {
         return $" on {args[i].Substring(1, 1)}-file ";
      }
   }
   return "";
}
string CheckForQuennPromotion(string WhichPiece, int i, string WhichField)
{
   int j = 0;
   for (j = 0; j < args[i].Length;)
   {
      j++;
   }

   if (WhichPiece == "P")
   {
      switch (args[i][j - 1])
      {
         case 'Q':
            return "and promotes to Queen";
         case 'R':
            return "and promotes to Rook";
         case 'B':
            return "and promotes to Bishop";
         case 'N':
            return "and promotes to Knight";
      }
   }
   return "and does an Invalid Promotion";
}