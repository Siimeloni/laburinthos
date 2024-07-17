using System;

public class PointerNode : Node {

    Direction ?pointer;

    public PointerNode(byte X, byte Y, bool isOrigin, bool isLastInRow) : base(X,Y) {
        if (isLastInRow) {
            if (isOrigin) {
                this.pointer = null;
            } else {
                this.pointer = Direction.Down;
            }
        } else {
            this.pointer = Direction.Right;
        }
    }

    public void MakeOrigin() {
        this.pointer = null;
    }

    public void SetPointer(Direction ?pntr) {
        if (pntr == null) {
            throw new NotImplementedException();
        }
        this.pointer = pntr;
    }

    public Direction? GetPointer() {
        return this.pointer;
    }
}