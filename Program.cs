using System;
public class Program {
    static void Main() {
        TicTacToe game = new TicTacToe();
        game.CreateMatrix(3,3);
<<<<<<< HEAD
        game.Controller("fill");
=======
        game.Controller("fill", "-");
>>>>>>> 12b17929152a18d2d13c85b8cba3486bff6aae64
        game.Start();
    }
}