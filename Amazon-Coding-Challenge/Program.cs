// Phase 1
// Initializing grid
char[,] grid = new Char[10, 10];

for (int i = 0; i < 10; i++)
{
    for (int j = 0; j < 10; j++)
    {
        // Passable positions are identified with ' '
        grid[i, j] = '0';

        if (i == 9 && j == 9)
        {
            // Exit position is identified with 'e'
            grid[i, j] = 'e';
        }
    }
}

// Obstacles are identified with '*'
grid[9,7] = '*';
grid[8,7] = '*';
grid[6,7] = '*';
grid[6,8] = '*';

// Print initial grid plus occupied locations
for (int i = 0; i < 10; i++)
{
    for (int j = 0; j < 10; j++)
    {
        Console.Write(grid[i,j] + "\t");
    }
    Console.WriteLine();
}

 
string[] path = new string[grid.GetLength(0) * grid.GetLength(1)]; 
int position = 0;

void FindPath(int row, int col, string direction) 
{
    if ((col < 0 || row < 0) || (col >= grid.GetLength(1)) || (row >= grid.GetLength(1)))
    {
        return ;
    }

    // Append the direction to the path
    path[position] = direction;  
    position++; 

    // Check if we have found the exit
    if (grid[row, col] == 'e')
    {
        PrintPath(path, 1, position - 1);
    }

    if (grid[row, col] == '0')
    {
        // The current cell is free. Mark it as visited
        grid[row, col] = 's';

        // Invoke recursion to explore all possible directions
        FindPath(row, col - 1, $"({row},{col})"); // left
        FindPath(row - 1, col, $"({row},{col})"); // up
        FindPath(row, col + 1, $"({row},{col})"); // right
        FindPath(row + 1, col, $"({row},{col})"); // down

    }
    // Remove the last direction from the path
    position--;
}

static void PrintPath(string[] path, int startPos, int endPos)
{
    Console.Write("Path: [");
    for (int pos = startPos; pos <= endPos; pos++)
    {
        Console.Write(path[pos]);
    }
    Console.Write("]");
    Console.WriteLine();
}

FindPath(0, 0, "S");

