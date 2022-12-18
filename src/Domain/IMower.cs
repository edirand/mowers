namespace Mowers.Domain;
public interface IMower
{
    void TurnLeft();
    void TurnRight();
    void MoveForward(ILawn lawn);
}
