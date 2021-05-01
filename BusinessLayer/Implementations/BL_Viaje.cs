using BusinessLayer.cast;
using BusinessLayer.Interfaces;
using Share.Entities;
using DataAccesLayer.Interfaces;
using System.Collections.Generic;
using BusinessLayer.Cast;
using DataAccesLayer.Implementations;
using Share.Enums;
using System;
using MercadoPago;
using MercadoPago.DataStructures.Payment;
using MercadoPago.Resources;
using System.Net.PeerToPeer.Collaboration;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Net.Mail;
using System.Threading;
using System.Text;
using System.Globalization;
using System.Linq;

namespace BusinessLayer.Implementations
{
    public class BL_Viaje : IBL_Viaje
    {

        private IDAL_Viaje dal = new DAL_Viaje();
        private IDAL_Usuario dalUsuario = new DAL_Usuario();
        private IDAL_Horario dalhorario = new DAL_Horario();
        private IDAL_Linea dalLinea = new DAL_Linea();

        public Asiento AddAsiento(Asiento a, int id)
        {
            return castAsiento.cast(dal.AddAsiento(castAsiento.cast(a), id));
        }

        public Dia AddDia(Dia di, int id)
        {
            return castDia.cast(dal.AddDia(castDia.cast(di), id));
        }

        public Pasaje AddPasaje(Pasaje pa, int id)
        {
            return new Pasaje();
        }

        public Viaje AddViaje(DtoViaje vi)
        {

            Horario or = castHorario.cast(dalhorario.GetHorario(vi.idHorario));
            var cantidad = or.vehiculo.cantAsientos;
            
            return castViaje.cast(dal.AddViaje(vi,castDia.castList(vi.DiasViaje),cantidad));
        }

        public void DeleteViaje(int Id)
        {
            dal.DeleteViaje(Id);
        }

        public Viaje GetViaje(int Id)
        {
            return castViaje.cast(dal.GetViaje(Id));
        }

        public List<Viaje> GetViajes()
        {
            return castViaje.castList(dal.GetViajes());
        }

        public Viaje UpdateViaje(Viaje vi)
        {
            return castViaje.cast(dal.UpdateViaje(castViaje.cast(vi)));
        }

        public List<DtViajeChofer> ViajesChofer(int id)
        {
           
            List<Viaje> viajes = castViaje.castList(dal.ViajesChofer(id));
            List<DtViajeChofer> ret = new List<DtViajeChofer>();
            foreach (Viaje vi in viajes)
            {
                DtViajeChofer item = new DtViajeChofer();
                item.estado = vi.estado;
                item.fechaFinal = vi.fechaFinal;
                item.fechaInicial = vi.fechaInicial;
                item.horario = vi.horario;
                item.idViaje = vi.idViaje;
                item.localizacion = vi.localizacion;
                ret.Add(item);
            }
            return ret;
        }

        public void comensarViaje(int id)
        {
            Viaje viaje = castViaje.cast(dal.GetViaje(id));
            ParadaAnterior pant = viaje.horario.linea.ParadaAnterior.Find(x => x.posicion == 2);
            DateTime now = DateTime.Now;
            DateTime llega = pant.tiempo.Add(now.TimeOfDay);
            dal.comensarViaje(id,llega);
        }

        public List<DtoViajePrecio> ViajePasaje(DtoViajePasaje dto)
        {
            string dia = "";
                if (dto.fecha.DayOfWeek == DayOfWeek.Monday)
                {
                    dia = "Lunes";
                }
                if (dto.fecha.DayOfWeek == DayOfWeek.Tuesday)
                {
                    dia = "Martes";
                } 
                if (dto.fecha.DayOfWeek == DayOfWeek.Wednesday)
                {
                    dia = "Miercoles";
                } 
                if (dto.fecha.DayOfWeek == DayOfWeek.Thursday)
                {
                    dia = "Jueves";
                } 
                if (dto.fecha.DayOfWeek == DayOfWeek.Friday)
                {
                    dia = "Viernes";
                } 
                if (dto.fecha.DayOfWeek == DayOfWeek.Saturday)
                {
                    dia = "Sabado";
                } 
                if (dto.fecha.DayOfWeek == DayOfWeek.Sunday)
                {
                    dia = "Domingo";
                } 
               
   
            
            List<Viaje> viajes = castViaje.castList(dal.ViajePasaje(dto,dia));
            
           
            List<DtoViajePrecio> retorno = new List<DtoViajePrecio>();
            foreach (Viaje item in viajes)
            {
                //FILTRO QUE LAS PARADAS ESTEN EN ORDEN 
                List<Parada_linea> filtroOrden = item.horario.linea.Parada;
                int ori = 0;
                int pos1 = 0;
                int pos2 = 0;
                foreach (Parada_linea e1 in filtroOrden)
                {
                    if (e1.Parada.idParada == dto.origen)
                    {
                        //EL IF FILTRA LOS VIAJES QUE YA PASARON POR ESA PARADA
                        if (e1.posicion < item.localizacion.ultimaPosicion)
                        {
                            break;
                        }
                        else
                        {
                            ori = 1;
                            pos1 = e1.posicion;
                        }
                    }
                    if (e1.Parada.idParada == dto.fin)
                    {
                        if (ori == 0)
                        {
                            break;
                        }
                        else
                        {
                            pos2 = e1.posicion;
                            break;
                        }
                    }
                }
                if(pos2 != 0)
                {
                    //FITRO LOS PRECIOS PARA VER SI LES CORRESPONDE ASIENTO
                    List<ParadaAnterior> filtroPrecio = item.horario.linea.ParadaAnterior;
                    float precio = 0;
                    int precioTotal = 0;
                    int precioParada = 0;
                   
                    foreach (ParadaAnterior p1 in filtroPrecio)
                    {
                       
                        if (p1.Precios.Count > 0)
                        {
                            precioParada = p1.Precios[p1.Precios.Count - 1].precio;
                        }
                        if (p1.posicion > pos1 && p1.posicion <= pos2)
                        {
                            
                                precioTotal += precioParada;
                                precio += precioParada; 
                            
                        }
                        else
                        {
                            if(p1.posicion != 1)
                                precioTotal += precioParada;
                        }
                    }
                    float num = precio/precioTotal;
                    if ((num * 100) < 50)
                    {
                        item.asientos = null;
                    }
                    else
                    {
                        List<Asiento> asientos = new List<Asiento>();
                        //FILTRO LOS ASIENTOS DISPONIBLES
                        foreach(Asiento asi in item.asientos)
                        {
                            bool dispo = true;
                            foreach(Pasaje pas in asi.pasajes) 
                            {
                                //FILTRO SI EL PASAJE ES DE LA FECHA
                                if((pas.fecha.Year == dto.fecha.Year) &&(pas.fecha.Month == dto.fecha.Month) &&(pas.fecha.Day == dto.fecha.Day))
                                {
                                    //FILTRO SI EL PASAJE ESTA OCUPANDO EL ASIENTO PARA ESE TRAMO DE VIAJE
                                    if ((pas.posicionOrigen < pos1 && pas.posicionDestino <= pos1) || (pas.posicionOrigen >= pos2 && pas.posicionDestino > pos2))
                                    {
                                    }
                                    else
                                    {
                                        dispo = false;
                                        break;
                                    }
                                }
                            }
                            if (dispo)
                            {
                                asientos.Add(asi);
                            }
                        }
                        if(asientos.Count != 0)
                        {
                            item.asientos = asientos;
                        }
                        else
                        {
                            item.asientos = null;
                        }
                    }
              
                    retorno.Add(new DtoViajePrecio { precio = (int)precio, viaje = item });

                }

            }
            return retorno;
        }
       
      
        public bool ComprarPasaje (DtoComprarPasaje dto)
        {
            Usuario us = castUsuario.cast(dalUsuario.GetUsuario(dto.idusuario));
            try
            {
                SDK.SetAccessToken("TEST-1285006718042431-110902-387af422bb02c9ad667290d7fbdaf6d5-133022683");
            }
            catch (Exception error)
            {
                Payment payment1 = new Payment()
                {
                    TransactionAmount = float.Parse(dto.transaction_amount),
                    Token = dto.token,
                    Description = "Compra de pasaje Uruguay Bus",
                    Installments = dto.installments,
                    PaymentMethodId = dto.payment_method_id,
                    IssuerId = dto.issuer_id,
                    Payer = new Payer()
                    {
                        Email = us.correo
                    }
                };
                // Guarda y postea el pago
                payment1.Save();
                //
                // Comprueba el estado del pago
                if (payment1.Status == MercadoPago.Common.PaymentStatus.approved)
                {
                    dto.nroDocumento = payment1.Payer.Identification.Value.Number;
                    if (payment1.Payer.Identification.Value.Type == "CI")
                    { dto.TipoDocumento = TipoDocumento.CI; }
                    else
                    { dto.TipoDocumento = TipoDocumento.OTRO; }
                    Viaje vi = castViaje.cast(dal.GetViaje(dto.idviaje));
                    int pos1 = 0;
                    int pos2 = 0;
                    string nombre1 = "";
                    string nombre2 = "";

                    //---- CREAR UN HASH
                    const string src = "abcdefghijklmnopqrstuvwxyz0123456789";
                    int length = 16;
                    var cod = new StringBuilder();
                    Random RNG = new Random();
                    for (var i = 0; i < length; i++)
                    {
                        var c = src[RNG.Next(0, src.Length)];
                        cod.Append(c);
                    }

                    //----CREAR EL PDF
                    Document doc = new Document(PageSize.A4);

                    MemoryStream ms = new MemoryStream();

                    System.Threading.Thread.Sleep(5000);
                    PdfWriter writer = PdfWriter.GetInstance(doc, ms); // PdfWriter.GetInstance(ManagementReportDoc, file);
                    writer.CloseStream = false;

                    doc.Open();
                    BarcodeQRCode codeQR = new BarcodeQRCode(cod.ToString(), 500, 500, null);
                    Image QR = codeQR.GetImage();
                    // QR.ScaleAbsolute(500, 500);
                    QR.SetAbsolutePosition((PageSize.A4.Width - QR.ScaledWidth) / 2, (PageSize.A4.Height - QR.ScaledHeight) / 2);
                    doc.Add(QR);
                    doc.Close();
                    byte[] bytes = ms.ToArray();
                    ms.Close();

                    //CONSIGO VARIABLES PARA EL PASAJE
                    foreach (Parada_linea pl in vi.horario.linea.Parada)
                    {
                        if (pl.Parada.idParada == dto.destino)
                        {
                            pos2 = pl.posicion;
                            nombre2 = pl.Parada.nombre;
                        }

                        if (pl.Parada.idParada == dto.origen)
                        {
                            pos1 = pl.posicion;
                            nombre1 = pl.Parada.nombre;
                        }

                    }
                    if (dto.plataforma == "web")
                    {

                        Pasaje pas = new Pasaje()
                        {
                            fecha = dto.fecha,
                            nroDocumento = dto.nroDocumento,
                            TipoDocumento = dto.TipoDocumento,
                            posicionOrigen = pos1,
                            posicionDestino = pos2,
                            nombreOrigen = nombre1,
                            nombreDestino = nombre2,
                            codigo = cod.ToString(),
                            precio = Int32.Parse(dto.transaction_amount)

                        };

                        dal.AddPasaje(castPasaje.cast(pas), dto.idviaje, dto.idusuario, dto.idAsiento);


                        //-------CREAR CORREO
                        using (MailMessage mail = new MailMessage())
                        {
                            mail.From = new MailAddress("correoppn@gmail.com");
                            mail.To.Add(us.correo);
                            mail.Subject = "Compra de pasaje UruguayBus";

                            string htmlString = "<html>"
                        + "<body>"
                        + "<p>Estimado Ms." + us.nombre + " " + us.apellido + ",</p>"
                        + "<p>Le informamos que la compra del pasaje para" + vi.horario.linea.nombre + " desde " + nombre1 + " hasta " + nombre2 + ",el dia " + dto.fecha.Day + "/" + dto.fecha.Month + "/" + dto.fecha.Year + " se a realisado con exito."
                        + "   Se le es adjuntado el codigo QR  para que lo muestre en el scaner una ves suba al vehiculo.</p>"
                        + "<p>Atentamente,<br>UruguayBus</br></p>"
                        + "</body>"
                        + "</html>"
                         ;
                            mail.Body = htmlString;
                            mail.IsBodyHtml = true;
                            mail.Attachments.Add(new Attachment(new MemoryStream(bytes), "CodigoQR.pdf", "text/pdf"));
                            using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                            {
                                smtp.UseDefaultCredentials = false;
                                smtp.Credentials = new System.Net.NetworkCredential("correoppn@gmail.com", "contrasenianet1234");
                                smtp.EnableSsl = true;
                                smtp.Send(mail);
                            }
                        }
                    }
                    else
                    {
                        Pasaje pas1 = new Pasaje()
                        {
                            fecha = dto.fecha,
                            nroDocumento = dto.nroDocumento,
                            TipoDocumento = dto.TipoDocumento,
                            posicionOrigen = pos1,
                            posicionDestino = pos2,
                            nombreOrigen = nombre1,
                            nombreDestino = nombre2,
                            precio = Int32.Parse(dto.transaction_amount)
                        };
                        dal.AddPasajePlatafoma(castPasaje.cast(pas1), dto.idviaje, dto.idAsiento);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
           
            
            Payment payment = new Payment()
            {
                TransactionAmount = float.Parse(dto.transaction_amount),
                Token = dto.token,
                Description = "Compra de pasaje Uruguay Bus",
                Installments = dto.installments,
                PaymentMethodId = dto.payment_method_id,
                IssuerId = dto.issuer_id,
                Payer = new Payer()
                {
                    Email = us.correo
                }
            };
            // Guarda y postea el pago
            payment.Save();
            //
            // Comprueba el estado del pago
             if(payment.Status == MercadoPago.Common.PaymentStatus.approved)
            {
                dto.nroDocumento = payment.Payer.Identification.Value.Number;
                if (payment.Payer.Identification.Value.Type == "CI")
                { dto.TipoDocumento = TipoDocumento.CI; }
                else
                { dto.TipoDocumento = TipoDocumento.OTRO; }
                Viaje vi = castViaje.cast(dal.GetViaje(dto.idviaje));
                int pos1 = 0;
                int pos2 = 0;
                string nombre1 = "";
                string nombre2 = "";

            //---- CREAR UN HASH
            const string src = "abcdefghijklmnopqrstuvwxyz0123456789";
            int length = 16;
            var cod = new StringBuilder();
            Random RNG = new Random();
            for (var i = 0; i < length; i++)
            {
                var c = src[RNG.Next(0, src.Length)];
                cod.Append(c);
            }

            //----CREAR EL PDF
            Document doc = new Document(PageSize.A4);

            MemoryStream ms = new MemoryStream();
           
            System.Threading.Thread.Sleep(5000);
            PdfWriter writer = PdfWriter.GetInstance(doc, ms); // PdfWriter.GetInstance(ManagementReportDoc, file);
             writer.CloseStream = false;
          
                doc.Open();
                BarcodeQRCode codeQR = new BarcodeQRCode(cod.ToString(), 500, 500, null);
                Image QR = codeQR.GetImage();
            // QR.ScaleAbsolute(500, 500);
            QR.SetAbsolutePosition((PageSize.A4.Width - QR.ScaledWidth) / 2, (PageSize.A4.Height - QR.ScaledHeight) / 2);
            doc.Add(QR);
            doc.Close();
            byte[] bytes = ms.ToArray();
            ms.Close();

            //CONSIGO VARIABLES PARA EL PASAJE
            foreach (Parada_linea pl in vi.horario.linea.Parada)
                    {
                if (pl.Parada.idParada == dto.destino)
                {
                    pos2 = pl.posicion;
                    nombre2 = pl.Parada.nombre;
                }

                if (pl.Parada.idParada == dto.origen)
                        {
                            pos1 = pl.posicion;
                            nombre1 = pl.Parada.nombre;
                        }
                        
                    }
                if (dto.plataforma == "web") 
                {
                    
                    Pasaje pas = new Pasaje()
                    {
                        fecha = dto.fecha,
                        nroDocumento = dto.nroDocumento,
                        TipoDocumento = dto.TipoDocumento,
                        posicionOrigen = pos1,
                        posicionDestino = pos2,
                        nombreOrigen = nombre1,
                        nombreDestino = nombre2,
                        codigo = cod.ToString(),
                        precio = Int32.Parse(dto.transaction_amount)
                        
                    };

                    dal.AddPasaje(castPasaje.cast(pas),dto.idviaje,dto.idusuario,dto.idAsiento);
                    

                    //-------CREAR CORREO
                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress("correoppn@gmail.com");
                        mail.To.Add(us.correo);
                        mail.Subject = "Compra de pasaje UruguayBus";
                    
                        string htmlString = "<html>"
                    + "<body>"
                    + "<p>Estimado Ms."+ us.nombre +" "+ us.apellido +",</p>"
                    + "<p>Le informamos que la compra del pasaje para"+ vi.horario.linea.nombre +" desde "+ nombre1 +" hasta "+nombre2+",el dia "+dto.fecha.Day+"/"+ dto.fecha.Month+"/"+ dto.fecha.Year+ " se a realisado con exito."
                    + "   Se le es adjuntado el codigo QR  para que lo muestre en el scaner una ves suba al vehiculo.</p>"
                    + "<p>Atentamente,<br>UruguayBus</br></p>"
                    + "</body>"
                    + "</html>"
                     ;
                        mail.Body = htmlString;
                        mail.IsBodyHtml = true;
                        mail.Attachments.Add(new Attachment(new MemoryStream(bytes), "CodigoQR.pdf","text/pdf"));
                        using (SmtpClient smtp = new SmtpClient ("smtp.gmail.com",587))
                        {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new System.Net.NetworkCredential("correoppn@gmail.com", "contrasenianet1234");
                            smtp.EnableSsl = true;
                            smtp.Send(mail);
                        }
                    }
                }
                else
                {
                    Pasaje pas1 = new Pasaje()
                    {
                        fecha = dto.fecha,
                        nroDocumento = dto.nroDocumento,
                        TipoDocumento = dto.TipoDocumento,
                        posicionOrigen = pos1,
                        posicionDestino = pos2,
                        nombreOrigen = nombre1,
                        nombreDestino = nombre2,
                        precio = Int32.Parse(dto.transaction_amount)
                    };
                    dal.AddPasajePlatafoma(castPasaje.cast(pas1), dto.idviaje, dto.idAsiento);
                }
                return true;
            }
            else
            {
                return false;
            }
        }


        public DtoValidarRet ValidarPasaje(DtoValidar dto)
        {
            DtoValidarRet ret = new DtoValidarRet();
            Viaje vi= castViaje.cast(dal.validarPasaje(dto));
            if(vi != null)
            {
                if(vi.idViaje == dto.idViaje)
                {
                    Pasaje pas = vi.pasajes.Find(x => x.codigo == dto.qr);
                    DateTime hoy = new DateTime();
                    if ((pas.fecha.Day == hoy.Day) && (pas.fecha.Month == hoy.Month) && (pas.fecha.Year == hoy.Year))
                    {
                        if ((vi.localizacion.ultimaPosicion >= pas.posicionOrigen) && (vi.localizacion.ultimaPosicion < pas.posicionDestino))
                        {
                            ret.valido = true;
                            ret.mensaje = "Disfrute de su viaje";
                            return ret;
                        }
                        else
                        {
                            ret.valido = false;
                            ret.mensaje = "Esta intentando subir en una parada la cual no esta dentro se su recorrido";
                        }
                    }
                    else
                    {
                        
                        ret.valido = false;
                        ret.mensaje = "Este pasaje no es para hoy sino para la fecha {pas.fecha}";
                        return ret;
                    }
                }
                else
                {
                   
                    ret.valido = false;
                    ret.mensaje = "Vehiculo equivocado este pasaje es para la linea {vi.horario.linea.nombre}";
                }

            }
            else
            {
                ret.valido = false;
                ret.mensaje = "El codigo QR no corresponde a ningu pasaje por favor asegurese de que esta utilisando el codigo que le fue enviado por correo";
                return ret;
            }
           
            return new DtoValidarRet();
        }

        public List<DtoViajeControl> ViajeControl()
        {
            List<Viaje> lv = castViaje.castList(dal.ViajesEnCurso());
            List<DtoViajeControl> ret = new List<DtoViajeControl>();
            foreach (Viaje vi in lv)
            {
                Parada_linea act = vi.horario.linea.Parada.Find(p => p.posicion == vi.localizacion.ultimaPosicion);
                DtoViajeControl dt = new DtoViajeControl()
                {
                    idviaje = vi.idViaje,
                    localisacion = act.Parada.geoReferencia,
                    nombre = vi.horario.linea.nombre
                };
                ret.Add(dt);
            }
            return ret;
        }

        public string MoverVehiculo(int id)
        {
            Viaje viaje = castViaje.cast(dal.GetViaje(id));
            int cant = viaje.horario.linea.ParadaAnterior.Count;
            int actual = viaje.localizacion.ultimaPosicion;
            if(actual + 1 == cant)
            {
                dal.FinalizarViaje(id);
                return "El viaje" + viaje.horario.linea.nombre + "a finalizado su recorrido";
            }
            else
            {
                ParadaAnterior pant = viaje.horario.linea.ParadaAnterior.Find(x => x.posicion == viaje.localizacion.ultimaPosicion + 2);
                DateTime now = DateTime.Now;
                DateTime llega = pant.tiempo.Add(now.TimeOfDay);
                dal.MoverVehiculo(id, llega);
                Viaje viaje1 = castViaje.cast(dal.GetViaje(id));
                string pap = viaje1.horario.linea.Parada.Find(x => x.Parada.idParada == viaje1.localizacion.ultimaPosicion).Parada.nombre;
                string ret = "El Vehículo de la Linea " + viaje.horario.linea.nombre + " llegara a la parada " + pap + " aproximadamente a las " +llega.TimeOfDay;
                return ret;
            }
            
            
        }

        public List<DtoProximoVehiculoRet> ProximoVehiculo(DtoProximoVehiculo dto) 
        {
            List<Viaje> viajes = castViaje.castList(dal.ProximoVehiculo(dto.idParada));
            Usuario us = castUsuario.cast(dalUsuario.GetUsuario(dto.idUsuario));
            List <DtoProximoVehiculoRet> ret = new List<DtoProximoVehiculoRet>();
            foreach(Viaje vi in viajes)
            {
                DtoProximoVehiculoRet item = new DtoProximoVehiculoRet()
                {
                    nombre = vi.horario.linea.nombre,
                    pasaje = false
                };
               foreach(Pasaje pas in us.pasajes)
                {
                    if (vi.pasajes.Exists(p => p.idPasaje == pas.idPasaje))
                        item.pasaje = true;
                }
                ret.Add(item);
  
            };
            return ret;
        }


        public List<ReporteRet> Reportes(Reporte dto)
        {
            List<ReporteRet> ret = new List<ReporteRet>();
            if(dto.tipo == "Pasajes")
            {
                if (dto.filtro == "Horario") 
                {
                    List<Horario> horarios = castHorario.castList(dal.horarioConPasajes(dto.fecha1,dto.fecha2));
                    List<Horario> otros = castHorario.castList(dalhorario.GetHorario());
                    List<DateTime> H = new List<DateTime>();
                    var p = new DateTime();
                    foreach (Horario item in horarios)
                    {
                        if (H.Find(h => (h.Hour == item.hora.Hour) && (h.Minute == item.hora.Minute) && (h.Second == item.hora.Second)) == p)
                        {
                            H.Add(item.hora);
                        }   
                    } 
                    
                    foreach (var item in H)
                    {
                        List<Pasaje> pasajes = castPasaje.castList(dal.pasajesporHorario(dto.fecha1, dto.fecha2, item));
                        ReporteRet resp = new ReporteRet();
                        resp.precioTotal = 0;
                        resp.cantPasajes = 0;

                        foreach (Pasaje pas in pasajes)
                        {
                            resp.cantPasajes++;
                            resp.precioTotal += pas.precio;
                        }
                        resp.fecha1 = dto.fecha1;
                        resp.fecha2 = dto.fecha2;
                        resp.horario = item;
                        ret.Add(resp);
                    }

                    foreach (Horario item in otros)
                    {
                        if (H.Find(h => (h.Hour == item.hora.Hour) && (h.Minute == item.hora.Minute) && (h.Second == item.hora.Second)) == p)
                        {
                            H.Add(item.hora);
                            ReporteRet resp = new ReporteRet();
                            resp.precioTotal = 0;
                            resp.cantPasajes = 0;
                            resp.horario = item.hora;
                            resp.fecha1 = dto.fecha1;
                            resp.fecha2 = dto.fecha2;
                            ret.Add(resp);
                        }
                    }

                    return ret.OrderBy(r => r.horario.Hour).ThenBy(r => r.horario.Minute).ThenBy(r => r.horario.Second).ToList();
                }

                if (dto.filtro == "Linea")
                {
                    List<Linea> lineas = castLinea.castList(dal.lineasConPasajes(dto.fecha1, dto.fecha2));
                    
                    foreach (Linea lin in lineas)
                    {
                        List<Pasaje> pasajes = castPasaje.castList(dal.pasajesporLinea(dto.fecha1, dto.fecha2, lin.idLinea));
                        ReporteRet resp = new ReporteRet();
                        resp.precioTotal = 0;
                        resp.cantPasajes = 0;

                        foreach (Pasaje pas in pasajes)
                        {
                            resp.cantPasajes++;
                            resp.precioTotal += pas.precio;
                        }
                        resp.fecha1 = dto.fecha1;
                        resp.fecha2 = dto.fecha2;
                        resp.nombreLinea = lin.nombre;
                        ret.Add(resp);
                    }

                    List<Linea> otras = castLinea.castList(dalLinea.GetLinea());
                   
                    foreach (Linea item in otras)
                    {
                       if(lineas.Find(l => l.idLinea == item.idLinea) == null)
                        {
                            ReporteRet resp = new ReporteRet();
                            resp.cantPasajes = 0;
                            resp.precioTotal = 0;
                            resp.fecha1 = dto.fecha1;
                            resp.fecha2 = dto.fecha2;
                            resp.nombreLinea = item.nombre;
                            ret.Add(resp);
                        }
                    }
                    
                    return ret.OrderBy(l => l.nombreLinea).ToList();
                }

               else 
               {
                    List<Pasaje> pasajes = castPasaje.castList(dal.soloPasajes(dto.fecha1, dto.fecha2));
                    ReporteRet resp = new ReporteRet();
                    resp.precioTotal = 0;
                    resp.cantPasajes = 0;
                    
                    foreach (Pasaje pas in pasajes)
                    {
                        resp.cantPasajes++;
                        resp.precioTotal += pas.precio;
                    }
                    resp.fecha1 = dto.fecha1;
                    resp.fecha2 = dto.fecha2;
                    ret.Add(resp);
                    return ret;
                    
               }

            }
            else
            {
                if (dto.filtro == "Horario")
                {
                    List<ReporteRet> retorno = new List<ReporteRet>();
                    List<Viaje> viajes = castViaje.castList(dal.viajesConPasajes(dto.fecha1, dto.fecha2));
                    foreach (var item in viajes)
                    {
                        float precioTotal = 0;
                        float precio = 0;
                       

                        foreach (var paradaAnterior in item.horario.linea.ParadaAnterior)
                        {

                            if (paradaAnterior.posicion != 1)
                                precioTotal += paradaAnterior.Precios[paradaAnterior.Precios.Count - 1].precio;
                        }
                        precioTotal = precioTotal * item.horario.vehiculo.cantAsientos;
                        List<Pasaje> pasajes = castPasaje.castList(dal.pasajesPorViaje(dto.fecha1, dto.fecha2, item.idViaje));

                        foreach (var pas in pasajes)
                        {
                            precio += pas.precio;
                        }
                        int cantDias = 0;
                        foreach (var dia in item.DiasViaje)
                        {
                            if (dia.nombre == "Lunes")
                            {
                                cantDias += CountDays(dto.fecha1, dto.fecha2, DayOfWeek.Monday);
                            }
                            if (dia.nombre == "Martes")
                            {
                                cantDias += CountDays(dto.fecha1, dto.fecha2, DayOfWeek.Tuesday);
                            }
                            if (dia.nombre == "Miercoles")
                            {
                                cantDias += CountDays(dto.fecha1, dto.fecha2, DayOfWeek.Wednesday);
                            }
                            if (dia.nombre == "Jueves")
                            {
                                cantDias += CountDays(dto.fecha1, dto.fecha2, DayOfWeek.Thursday);
                            }
                            if (dia.nombre == "Viernes")
                            {
                                cantDias += CountDays(dto.fecha1, dto.fecha2, DayOfWeek.Friday);
                            }
                            if (dia.nombre == "Sabado")
                            {
                                cantDias += CountDays(dto.fecha1, dto.fecha2, DayOfWeek.Saturday);
                            }
                            if (dia.nombre == "Domingo")
                            {
                                cantDias += CountDays(dto.fecha1, dto.fecha2, DayOfWeek.Sunday);
                            }
                        }
                        ReporteRet r = new ReporteRet();
                        r.fecha1 = dto.fecha1;
                        r.fecha2 = dto.fecha2;
                        r.recaudacion = precio;
                        r.horario = item.horario.hora;
                        r.precioTotal = (int)precioTotal;
                        r.salidas = cantDias;
                        retorno.Add(r);
                    }
                    List<DateTime> H = new List<DateTime>();
                    var p = new DateTime();
                    foreach (ReporteRet item in retorno)
                    {
                        if (H.Find(h => (h.Hour == item.horario.Hour) && (h.Minute == item.horario.Minute) && (h.Second == item.horario.Second)) == p)
                        {
                            H.Add(item.horario);
                        }
                    }
                    List<ReporteRet> ret2 = new List<ReporteRet>();
                    foreach (var horario in H)
                    {
                        ReporteRet r = new ReporteRet();
                        r.horario = horario;
                        
                        foreach (var reporte in retorno)
                        {
                            if ((reporte.horario.Hour == horario.Hour) && (reporte.horario.Minute == horario.Minute) && (reporte.horario.Second == horario.Second))
                            {
                                r.fecha1 = reporte.fecha1;
                                r.fecha2 = reporte.fecha2;
                                r.recaudacion += reporte.recaudacion;
                                r.regla += reporte.precioTotal * reporte.salidas;
                                r.precioTotal += reporte.precioTotal;
                                r.salidas += reporte.salidas;
                            }
                        }
                        ret2.Add(r);
                    }
                    foreach (var item in ret2)
                    {
                        item.porcentaje = ((item.recaudacion * 100) / item.regla);
                    }
                    return ret2;
                      
                }

                if (dto.filtro == "Linea")
                {

                    List<ReporteRet> retorno = new List<ReporteRet>();
                    List<Viaje> viajes = castViaje.castList(dal.viajesConPasajes(dto.fecha1, dto.fecha2));
                    foreach (var item in viajes)
                    {
                        float precioTotal = 0;
                        float precio = 0;


                        foreach (var paradaAnterior in item.horario.linea.ParadaAnterior)
                        {

                            if (paradaAnterior.posicion != 1)
                                precioTotal += paradaAnterior.Precios[paradaAnterior.Precios.Count - 1].precio;
                        }
                        precioTotal = precioTotal * item.horario.vehiculo.cantAsientos;
                        List<Pasaje> pasajes = castPasaje.castList(dal.pasajesPorViaje(dto.fecha1, dto.fecha2, item.idViaje));

                        foreach (var pas in pasajes)
                        {
                            precio += pas.precio;
                        }
                        int cantDias = 0;
                        foreach (var dia in item.DiasViaje)
                        {
                            if (dia.nombre == "Lunes")
                            {
                                cantDias += CountDays(dto.fecha1, dto.fecha2, DayOfWeek.Monday);
                            }
                            if (dia.nombre == "Martes")
                            {
                                cantDias += CountDays(dto.fecha1, dto.fecha2, DayOfWeek.Tuesday);
                            }
                            if (dia.nombre == "Miercoles")
                            {
                                cantDias += CountDays(dto.fecha1, dto.fecha2, DayOfWeek.Wednesday);
                            }
                            if (dia.nombre == "Jueves")
                            {
                                cantDias += CountDays(dto.fecha1, dto.fecha2, DayOfWeek.Thursday);
                            }
                            if (dia.nombre == "Viernes")
                            {
                                cantDias += CountDays(dto.fecha1, dto.fecha2, DayOfWeek.Friday);
                            }
                            if (dia.nombre == "Sabado")
                            {
                                cantDias += CountDays(dto.fecha1, dto.fecha2, DayOfWeek.Saturday);
                            }
                            if (dia.nombre == "Domingo")
                            {
                                cantDias += CountDays(dto.fecha1, dto.fecha2, DayOfWeek.Sunday);
                            }
                        }
                        ReporteRet r = new ReporteRet();
                        r.fecha1 = dto.fecha1;
                        r.fecha2 = dto.fecha2;
                        r.recaudacion = precio;
                        r.idLinea = item.horario.linea.idLinea;
                        r.nombreLinea = item.horario.linea.nombre;
                        r.horario = item.horario.hora;
                        r.precioTotal = (int)precioTotal;
                        r.salidas = cantDias;
                        retorno.Add(r);
                    }
                    List<int> H = new List<int>();
                    var p = new DateTime();
                    foreach (ReporteRet item in retorno)
                    {
                        if (!H.Contains(item.idLinea))
                        {
                            H.Add(item.idLinea);
                        }
                    }
                    List<ReporteRet> ret2 = new List<ReporteRet>();
                    foreach (var idLinea in H)
                    {
                        ReporteRet r = new ReporteRet();

                        r.idLinea = idLinea;
                        foreach (var reporte in retorno)
                        {
                            if (reporte.idLinea == idLinea)
                            {
                                r.nombreLinea = reporte.nombreLinea;
                                r.fecha1 = reporte.fecha1;
                                r.fecha2 = reporte.fecha2;
                                r.recaudacion += reporte.recaudacion;
                                r.regla += reporte.precioTotal * reporte.salidas;
                                r.precioTotal += reporte.precioTotal;
                                r.salidas += reporte.salidas;
                            }
                        }
                        ret2.Add(r);
                    }
                    foreach (var item in ret2)
                    {
                        item.porcentaje = ((item.recaudacion * 100) / item.regla);
                    }
                    return ret2;


                }

                else
                {
                    List<ReporteRet> retorno = new List<ReporteRet>();
                    List<Viaje> viajes = castViaje.castList(dal.viajesConPasajes(dto.fecha1,dto.fecha2));
                    foreach (var item in viajes)
                    {
                        float precioTotal = 0;
                        float precio = 0;
                        float porcentaje = 0;

                        foreach (var paradaAnterior in item.horario.linea.ParadaAnterior)
                        {

                            if(paradaAnterior.posicion != 1)
                                    precioTotal += paradaAnterior.Precios[paradaAnterior.Precios.Count - 1].precio;
                        }
                        precioTotal = precioTotal * item.horario.vehiculo.cantAsientos;
                        List<Pasaje> pasajes = castPasaje.castList(dal.pasajesPorViaje(dto.fecha1,dto.fecha2,item.idViaje));
                       
                        foreach (var pas in pasajes)
                        {
                            precio += pas.precio;
                        }
                        int cantDias = 0;
                        foreach (var dia in item.DiasViaje)
                        {
                            if (dia.nombre == "Lunes")
                            {
                               cantDias += CountDays(dto.fecha1, dto.fecha2, DayOfWeek.Monday); 
                            }
                            if (dia.nombre == "Martes")
                            {
                               cantDias += CountDays(dto.fecha1, dto.fecha2, DayOfWeek.Tuesday);
                            }
                            if (dia.nombre == "Miercoles")
                            {
                                cantDias += CountDays(dto.fecha1, dto.fecha2, DayOfWeek.Wednesday);
                            }
                            if (dia.nombre == "Jueves")
                            {
                                cantDias += CountDays(dto.fecha1, dto.fecha2, DayOfWeek.Thursday);
                            }
                            if (dia.nombre == "Viernes")
                            {
                                cantDias += CountDays(dto.fecha1, dto.fecha2, DayOfWeek.Friday);
                            }
                            if (dia.nombre == "Sabado")
                            {
                                cantDias += CountDays(dto.fecha1, dto.fecha2, DayOfWeek.Saturday);
                            }
                            if (dia.nombre == "Domingo")
                            {
                                cantDias += CountDays(dto.fecha1, dto.fecha2, DayOfWeek.Sunday); 
                            }
                        }

                        porcentaje = ((precio * 100) / (precioTotal * cantDias));
                        ReporteRet r = new ReporteRet();
                        r.fecha1 = dto.fecha1;
                        r.fecha2 = dto.fecha2;
                        r.porcentaje = porcentaje;
                        r.nombreLinea = item.horario.linea.nombre;
                        r.horario = item.horario.hora;
                        r.matricula = item.horario.vehiculo.matricula;
                        r.precioTotal = (int)precioTotal;
                        r.idViaje = item.idViaje;
                        r.salidas = cantDias;
                        retorno.Add(r);
                    }
                    return retorno.OrderBy(l => l.porcentaje).ToList();
                }

            }
           
        }

        static int CountDays(DateTime start, DateTime end, DayOfWeek day)
        {
            TimeSpan ts = end - start;                       // Total duration
            int count = (int)Math.Floor(ts.TotalDays / 7);   // Number of whole weeks
            int remainder = (int)(ts.TotalDays % 7);         // Number of remaining days
            int sinceLastDay = (int)(end.DayOfWeek - day);   // Number of days since last [day]
            if (sinceLastDay < 0) sinceLastDay += 7;         // Adjust for negative days since last [day]

            // If the days in excess of an even week are greater than or equal to the number days since the last [day], then count this one, too.
            if (remainder >= sinceLastDay) count++;

            return count;
        }
    }//CIERRA

}
