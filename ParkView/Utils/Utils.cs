namespace ParkView.Utils
{
    public class Utils
    {
        public static string WhatsappAccessToken => "EAAHMAqGADscBOzu00DJStOFDSLwyUbZBLZBEZCYJeKunsPCLNOZAGXT7arjVi2laVoHS6gp6KofLsTrA7FCJKXuWUohOjZAK5SoxIKbHBcQIfcP6gR00OZBZCyFIWfBURE3TWckC3Ed3IwZCntPcIxZBZCMnABd7ZCZAjXNKaNyo04LDPZAQtIE9EcmixmfDLtkZAKdTZC9VgRzsOSJo619oH8BgD6K8fJbJYsZD";
        public static string WhatasppApiUrl => "https://graph.facebook.com/v17.0/106615725606315/messages";

        public static string GetWhatsappMediaPayload(string whatsappNumber, string mediaType, string mediaUrl, string fileName = null)
        {
            return string.Format(@"{{
                        ""messaging_product"": ""whatsapp"",
                        ""recipient_type"": ""individual"",
                        ""to"": ""{0}"",
                        ""type"": ""{1}"",
                        ""{2}"": {{
                            ""link"": ""{3}"",
                            ""filename"": ""{4}""
                        }}
                    }}", whatsappNumber, mediaType, mediaType, mediaUrl, fileName ?? DateTime.Now + ".pdf");
        }

        public static string GetWhatsappTextPayload(string whatsappNumber, string message)
        {
            return string.Format(@"{{
                        ""messaging_product"": ""whatsapp"",
                        ""recipient_type"": ""individual"",
                        ""to"": ""{0}"",
                        ""type"": ""text"",
                        ""text"": {{
                            ""body"": ""{1}""
                        }}
                    }}", whatsappNumber, message);
        }

        public static string GetWhatsappBookingPayload(string whatsappNumber, string checkinDate, string checkoutDate, string hotelName, string hotelAddress, string username)
        {
            return string.Format(@"{{
                        ""messaging_product"": ""whatsapp"",
                        ""to"": ""{0}"",
                        ""type"": ""template"",
                        ""template"": {{
                            ""name"": ""booking_complete_message"",
                            ""language"": {{
                                ""code"": ""en_US""
                            }},
                            ""components"": [
                                {{
                                    ""type"": ""body"",
                                    ""parameters"": [
                                        {{
                                            ""type"": ""text"",
                                            ""text"": ""{1}""
                                        }},
                                        {{
                                            ""type"": ""text"",
                                            ""text"": ""ParkView Hotels.""
                                        }},
                                        {{
                                            ""type"": ""text"",
                                            ""text"": ""{2}""
                                        }},
                                        {{
                                            ""type"": ""text"",
                                            ""text"": ""{3}""
                                        }},
                                        {{
                                            ""type"": ""text"",
                                            ""text"": ""{4}""
                                        }},
                                        {{
                                            ""type"": ""text"",
                                            ""text"": ""{5}""
                                        }}
                                    ]
                                }}
                            ]
                        }}
                    }}", whatsappNumber, username, hotelName, hotelAddress, checkinDate, checkoutDate);
        }

        public static string GetWhatsappContactPayload(string whatsappNumber, string username)
        {
            return string.Format(@"{{
                        ""messaging_product"": ""whatsapp"",
                        ""to"": ""{0}"",
                        ""type"": ""template"",
                        ""template"": {{
                            ""name"": ""customer_contact_message"",
                            ""language"": {{
                                ""code"": ""en_US""
                            }},
                            ""components"": [
                                {{
                                    ""type"": ""body"",
                                    ""parameters"": [
                                        {{
                                            ""type"": ""text"",
                                            ""text"": ""{1}""
                                        }},
                                        {{
                                            ""type"": ""text"",
                                            ""text"": ""ParkView Hotels.""
                                        }}
                                    ]
                                }}
                            ]
                        }}
                    }}", whatsappNumber, username);
        }



        public static string GetInvoiceTemplate(string username, string bookingDate, string bookingId, string roomPrice, string cabPrice, string foodPrice, string checkInDate, string totalPrice)
        {
            return string.Format(@"

<style>

        .footer {{
            margin-top: 30px;
        }}

        .footer-info {{
            float: none;
            position: running(footer);
            margin-top: -25px;
        }}

        .page-container {{
            display: block;
            position: running(pageContainer);
            margin-top: -25px;
            font-size: 12px;
            text-align: right;
            color: #999;
        }}

            .page-container .page::after {{
                content: counter(page);
            }}

            .page-container .pages::after {{
                content: counter(pages);
            }}


        @page {{
            @bottom-right {{
                content: element(pageContainer);
            }}

            @bottom-left {{
                content: element(footer);
            }}
        }}
</style>

<div class=""page-container"">
    Page
    <span class=""page""></span>
    of
    <span class=""pages""></span>
</div>

<div class=""logo-container"">
    <img style=""height: 18px""
         src=""{0}"">
</div>

<table class=""invoice-info-container"">
    <tr>
        <td rowspan=""2"" class=""client-name"">
            {1}
        </td>
        <td>
            ParkView Co
        </td>
    </tr>
    <tr>
        <td>
            123 Main Street
        </td>
    </tr>
    <tr>
        <td>
            Invoice Date: <strong>{2}</strong>
        </td>
        <td>
            Bangalore Bellandur, 560103
        </td>
    </tr>
    <tr>
        <td>
            Invoice No: <strong>{3}</strong>
        </td>
        <td>
            support@parkview.com
        </td>
    </tr>
</table>


<table class=""line-items-container"">
    <thead>
        <tr>
            <th class=""heading-description"">Description</th>
            <th class=""heading-price"">Price</th>
            <th class=""heading-subtotal"">Subtotal</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>Hotel Room</td>
            <td class=""right"">{4}</td>
            <td class=""bold"">{5}</td>
        </tr>
        <tr>
            <td>Cab Service</td>
            <td class=""right"">{6}</td>
            <td class=""bold"">{7}</td>
        </tr>
        <tr>
            <td>Food Service</td>
            <td class=""right"">{8}</td>
            <td class=""bold"">{9}</td>
        </tr>
    </tbody>
</table>


<table class=""line-items-container has-bottom-border"">
    <thead>
        <tr>
            <th>Payment Info</th>
            <th>Total Amount</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td class=""payment-info"">
                <div>
                    Account No: <strong>123567744</strong>
                </div>
                <div>
                    Routing No: <strong>120000547</strong>
                </div>
            </td>
            <td class=""large"">{10}</td>
            <td class=""large total"">{11}</td>
        </tr>
    </tbody>
</table>", "~/images/logo.svg", username, bookingDate, bookingId, roomPrice, roomPrice, cabPrice, cabPrice, foodPrice, foodPrice, checkInDate, totalPrice);
        }


    }
}
