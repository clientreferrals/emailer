using System;

namespace NetMail.Utility
{
    public class Response<T>
    {
        private T _data;
        private bool _success = false;
        private string _message;

        public bool Success
        {
            get { return _success; }
            set { _success = value; }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public T Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public Response(T data)
        {
            _success = true;
            _data = data;
        }

        public Response(Exception exception)
        {
            _success = false;
            _message = exception.Message;
        }
    }
}
