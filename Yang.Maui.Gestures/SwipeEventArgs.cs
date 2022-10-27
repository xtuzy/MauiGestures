namespace Yang.Maui.Gestures;

public class SwipeEventArgs : EventArgs
{
    public Point BegainPoint { get; }
    public Point EndPoint { get; }
    public double VelocityX { get; }
    public double VelocityY { get; }
    public SwipeDirection Direction { get; }
    public SwipeEventArgs(Point begainPoint, Point endPoint, double velocityX, double velocityY, SwipeDirection direction)
    {
        VelocityX = velocityX;
        VelocityY = velocityY;
        BegainPoint = begainPoint;
        EndPoint = endPoint;
        Direction = direction;
    }
}