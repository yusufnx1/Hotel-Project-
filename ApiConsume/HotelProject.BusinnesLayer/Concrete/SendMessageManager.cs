﻿using HotelProject.BusinnesLayer.Abstrack;
using HotelProject.DataAccesLayer.Abstrack;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinnesLayer.Concrete
{
    public class SendMessageManager : ISendMessageService
    {
        private readonly ISendMessageDal _sendMessageDal;

        public SendMessageManager(ISendMessageDal sendMessageDal)
        {
            _sendMessageDal = sendMessageDal;
        }

        public void TDelete(SendMessage t)
        {
            _sendMessageDal.Delete(t);
        }

        public SendMessage TGetById(int id)
        {
            return _sendMessageDal.GetById(id);
        }

        public List<SendMessage> TGetList()
        {
           return _sendMessageDal.GetList();
        }

        public int TGetSenMessageCount()
        {
           return _sendMessageDal.GetSenMessageCount();
        }

        public void TInsert(SendMessage t)
        {
            _sendMessageDal.Insert(t);
        }

        public void TUpdate(SendMessage t)
        {
            _sendMessageDal.Update(t);
        }
    }
}
