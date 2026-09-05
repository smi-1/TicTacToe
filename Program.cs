using System;
public class Program {
    static void Main() {
        TicTacToe game = new TicTacToe();
        game.CreateMatrix(3,3);
        game.Controller("fill");
        game.Start();
    }
}