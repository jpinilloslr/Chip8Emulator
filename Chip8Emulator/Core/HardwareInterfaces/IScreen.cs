namespace Chip8Emulator.Core.HardwareInterfaces
{
    public interface IScreen
    {
        void Refresh(GraphicMemory graphicMemory);
    }
}