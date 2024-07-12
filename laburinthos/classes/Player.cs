using System;

public class Player{
    private int pos_x=0, pos_y=0;

    public int[] move_right(){
        pos_x = pos_x + 1;
        return new [] {pos_x, pos_y};
    }
    public int[] move_left(){
        pos_x = pos_x - 1;
        return new [] {pos_x, pos_y};
    }
    public int[] move_up(){
        pos_y = pos_y - 1;
        return new [] {pos_x, pos_y};
    }
    public int[] move_down(){
        pos_y = pos_y + 1;
        return new [] {pos_x, pos_y};
    }

}