using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Windows.UI.Xaml;

namespace App2
{
    public enum HttpVerbs
    {
        GET,
        POST,
        DELETE,
        PUT
    }

    public class RestClient
    {
        public string endPoint { get; set; }
        public HttpVerbs httpMethod { get; set; }
        public string userName { get; set; }
        public string userPass { get; set; }

        public RestClient(string v, HttpVerbs verb)
        {
            endPoint = "http://localhost/cesapi/" + v;
            httpMethod = verb;
            userName = string.Empty;
            userPass = string.Empty;
        }

        public string postData()
        {
            string strResponseValue = string.Empty;

            return strResponseValue;
        }

        public string makeLoginRequest(string un, string up)
        {
            userName = HttpUtility.UrlEncode(un);
            userPass = HttpUtility.UrlEncode(up);

            string strResponseValue = string.Empty; //string that will be returned with repsonse data

            string strRequestBody ="grant_type=password&username=" + userName + "&password=" + userPass;
            var data = Encoding.ASCII.GetBytes(strRequestBody);

            //var client = new RestClient("token", HttpVerbs.GET, username, userpassword); //new rest client
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint); //create the http request
            request.Method = httpMethod.ToString();
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            var bodyStream = request.GetRequestStream();
            bodyStream.Write(data, 0, strRequestBody.Length);
            bodyStream.Close();
            
                                                            
            HttpWebResponse response = null;

            try //get the response
            {
                response = (HttpWebResponse)request.GetResponse();

                using (Stream responseStream = response.GetResponseStream()) //get response stream
                {
                    if (responseStream != null) //if not empty stream
                    {
                        using (StreamReader reader = new StreamReader(responseStream)) //create reader to read stream into string
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                strResponseValue = "{\"errorMesages\":[\"" + ex.Message.ToString() + "\"],\"errors\":{}}";
            }

            finally
            {
                if (response != null)
                {
                    ((IDisposable)response).Dispose();
                }
            }
            return strResponseValue;
        }

        public string sendData()
        {
            string token = string.Empty;
            string strResponseValue = string.Empty; //string that will be returned with repsonse data
            token = ((App)Application.Current).userSession;
            string strRequestBody = "grant_type=password&username=" + userName + "&password=" + userPass;
            var data = Encoding.ASCII.GetBytes(strRequestBody);

            //var client = new RestClient("token", HttpVerbs.GET, username, userpassword); //new rest client

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint); //create the http request
            request.Method = httpMethod.ToString();
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            var bodyStream = request.GetRequestStream();
            bodyStream.Write(data, 0, strRequestBody.Length);
            bodyStream.Close();


            HttpWebResponse response = null;

            try //get the response
            {
                response = (HttpWebResponse)request.GetResponse();

                using (Stream responseStream = response.GetResponseStream()) //get response stream
                {
                    if (responseStream != null) //if not empty stream
                    {
                        using (StreamReader reader = new StreamReader(responseStream)) //create reader to read stream into string
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strResponseValue = "{\"errorMesages\":[\"" + ex.Message.ToString() + "\"],\"errors\":{}}";
            }

            finally
            {
                if (response != null)
                {
                    ((IDisposable)response).Dispose();
                }
            }
            return strResponseValue;
        }
    }
}
