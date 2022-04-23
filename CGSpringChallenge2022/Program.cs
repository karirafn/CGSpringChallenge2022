using System;
using System.IO;
using System.Text;
using System.Collections;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Player
{
    static void Main(string[] args)
    {
        Game game = new Game();
        
        while (true)
        {
            game.UpdateBases();
            game.UpdateEntities();
            game.Act();
        }
    }
}
