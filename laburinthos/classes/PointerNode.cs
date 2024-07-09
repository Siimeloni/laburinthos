using System;

public enum PointerDirection {Up, Right, Down, Left, None};

public class PointerNode : Node {

    PointerDirection ?pointer;
    bool isOrigin = false;

    public PointerNode(byte X, byte Y, bool isOrigin, bool isLastInRow) : base(X,Y) {
        if (isLastInRow) {
            if (isOrigin) {
                this.pointer = PointerDirection.None;
                this.isOrigin = isOrigin;
            } else {
                this.pointer = PointerDirection.Down;
            }
        } else {
            this.pointer = PointerDirection.Right;
        }
    }

    public void makeOrigin() {
        this.isOrigin = true;
        this.pointer = PointerDirection.None;
    }

    public void setPointer(PointerDirection pntr) {
        if (pntr == PointerDirection.None) {
            throw new NotImplementedException();
        }
        this.pointer = pntr;
    }


}