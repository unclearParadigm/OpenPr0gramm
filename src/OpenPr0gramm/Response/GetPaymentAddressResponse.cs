﻿namespace OpenPr0gramm.Response
{
    public class GetPaymentAddressResponse : Pr0grammResponse
    {
        public string Address { get; private set; }
        public decimal Amount { get; private set; }
    }
}
