using System.Collections;
using System.Collections.Generic;
using Thriving.Win32Tools.Internal;

namespace Thriving.Win32Tools
{
    public class InputArray : IEnumerable<Internal.Input>
    {
        private readonly List<Internal.Input> _container;
        public InputArray()
        {
            _container = new List<Internal.Input>();
        }

        public void Add(KeyboardInput keyboardInput)
        {
            _container.Add(new Internal.Input()
            {
                InputType = Internal.InputType.Keyboard,
                KeyboardInput = keyboardInput
            });
        }

        public void Add(MouseInput mouseInput)
        {
            _container.Add(new Internal.Input()
            {
                InputType = Internal.InputType.Mouse,
                MouseInput = mouseInput
            });
        }

        public void Add(HardwareInput hardwareInput)
        {
            _container.Add(new Internal.Input()
            {
                InputType = Internal.InputType.Hardware,
                HardwardInput = hardwareInput
            });
        }

        public void Clear()
        {
            _container.Clear();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _container.GetEnumerator();
        }

        IEnumerator<Input> IEnumerable<Input>.GetEnumerator()
        {
            return _container.GetEnumerator();
        }
    }
}
