
class TicTacToe {
    bool playing = true;
    string turn = "O";
    string last_turn = "";
    string[,]? matrix = null;
    public void CreateMatrix(int height, int width) {
    
    string[,] newMatrix = new string[height,width];
    matrix = newMatrix;
    }
    public void Controller(params string[] actions) {
        if (matrix != null) {
        for (var row = 0;row<matrix?.GetLength(0);row++) {
            for (var column = 0;column<matrix.GetLength(1);column++) {
                if (actions[0] == "fill") { matrix[row,column] = actions[1]; }
            }
        }
        } else { Console.WriteLine("Please use CreateMatrix(int height,int width) before using the MatrixController method");}
    }

    public void Calculate() {
        for (var row = 0;row<matrix?.GetLength(0);row++) {
            int count_row = 0;
            int count_column = 0;
            int count_diagonal_top = 0;
            int count_diagonal_bottom = 0;
            string? last_row_item = null;
            string? last_column_item = null;
            string? last_diagonal_top = null;
            string? last_diagonal_bottom = null;
            for (int column = 0; column < matrix.GetLength(1); column++) {
                
                if (last_diagonal_top == null) { last_diagonal_top = matrix[0,0]; }
                if (last_diagonal_bottom == null) { last_diagonal_bottom = matrix[matrix.GetLength(1)-1,0]; }
                if (last_row_item == null) { last_row_item = matrix[row, column]; }
                if (last_column_item == null) { last_column_item = matrix[column,row]; }
                if (matrix[row, column] == last_row_item && matrix[row, column] != "-") { count_row++; } else { count_row = 0; }
                if (matrix[column,row] == last_column_item && matrix[column,row] != "-") { count_column++; } else { count_column = 0; }
                if (matrix[column, column] == last_diagonal_top && matrix[column, column] != "-") { count_diagonal_top++; } else { count_diagonal_top = 0; }
                if (matrix[matrix.GetLength(1)-1-column, column] == last_diagonal_bottom && matrix[row, column] != "-") { count_diagonal_bottom++; } else { count_diagonal_bottom = 0; }

                // Ritar upp rutan
                Console.Write(matrix[row, column].PadLeft(5));

                if (count_row > matrix.GetLength(1)) { count_row = 0; }
                else if (count_row == matrix.GetLength(1)) { playing = false; }
                if (count_column > matrix.GetLength(1)) { count_column = 0; }
                else if (count_column == matrix.GetLength(1)) { playing = false; }
                if (count_diagonal_top > matrix.GetLength(1)) { count_diagonal_top = 0; }
                else if (count_diagonal_top == matrix.GetLength(1)) { playing = false; }
                if (count_diagonal_bottom > matrix.GetLength(1)) { count_diagonal_bottom = 0; }
                else if (count_diagonal_bottom == matrix.GetLength(1)) { playing = false; }
            }
            Console.WriteLine();Console.WriteLine();
        }
    }
    public void Start() {
        while (playing) {
            this.Calculate();
            
            if (playing == false) {
                Console.WriteLine($"\nSPELARE {last_turn} VANN!\n");
                break;
            }
            Console.WriteLine($"Player {turn}'s tur att spela, välj rad och kolumn. Instruktion: rad,kolumn med siffror t. ex 1,2, använder array index så siffror mellan 0 och 2");
            var result = Console.ReadLine().Split(",");
            var result_row = Convert.ToInt32(result[0]);
            var result_column = Convert.ToInt32(result[1]);
            matrix?[result_row,result_column] = turn;

            if (turn == "O") {
                last_turn = "O";
                turn = "X";
            }
            else if (turn == "X") {
                last_turn = "X";
                turn = "O";
            }
        }
    }

}

