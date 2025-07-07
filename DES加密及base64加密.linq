<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>devAPI</Namespace>
  <Namespace>System.Security.Cryptography</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
	//{"content":"测试一下","srcAddr":"106509113","userName":"suzhos","userPwd":"9sHW0fFmyMas","exteCode":"050","destAddr":"13724217957","clientType":"11"}


	var obj = new
	{
		content="测试一下",
		srcAddr="106509113",
		userName="suzhos",
		userPwd="9sHW0fFmyMas",
		exteCode="050",
		destAddr="13724217957",
		clientType="11"
	};
	
	var result=Encrypt.ToDESEncrypt(JsonConvert.SerializeObject(obj));
	
	Console.WriteLine(result);
}

namespace devAPI
{
	public class Encrypt
	{
		private static string sKey = "ipimbop@";
		/// <summary>
		/// 将字符串转为Base64
		/// </summary>
		/// <param name="strSource">要转换的数据源</param>
		/// <returns>转换后的Base64位的数据</returns>
		public static string EncodeBase64(byte[] strSource)
		{
			try
			{
				return Convert.ToBase64String(strSource);
			}
			catch
			{
				return "";
			}
		}

		/// <summary>
		/// 将Base64位的数据转为字符串
		/// </summary>
		/// <param name="strResult">Base64数据</param>
		/// <returns>转换后的字符串</returns>
		public static string DecodeBase64(byte[] strResult)
		{
			try
			{
				return Encoding.UTF8.GetString(strResult);
			}
			catch
			{
				return "";
			}
		}

		public static byte[] DecodeBase64(string result)
		{
			byte[] bytes = Convert.FromBase64String(result);
			return bytes;
		}


		/// <summary>
		/// DES加密算法
		/// </summary>
		/// <param name="encryptString">要加密的字符串</param>
		/// <param name="sKey">加密码Key</param>
		/// <returns>正确返回加密后的结果，错误返回源字符串</returns>
		public static string ToDESEncrypt(string encryptString)
		{
			try
			{
				byte[] keyBytes = Encoding.UTF8.GetBytes(sKey);
				byte[] keyIV = keyBytes;
				byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
				DESCryptoServiceProvider desProvider = new DESCryptoServiceProvider();
				// java 默认的是ECB模式，PKCS5padding；c#默认的CBC模式，PKCS7padding 所以这里我们默认使用ECB方式
				desProvider.Mode = CipherMode.ECB;
				MemoryStream memStream = new MemoryStream();
				CryptoStream crypStream = new CryptoStream(memStream, desProvider.CreateEncryptor(keyBytes, keyIV), CryptoStreamMode.Write);
				crypStream.Write(inputByteArray, 0, inputByteArray.Length);
				crypStream.FlushFinalBlock();
				byte[] desbytes = memStream.ToArray();
				return EncodeBase64(desbytes);
			}
			catch
			{
				return encryptString;
			}
		}

		/// <summary>
		/// DES解密算法
		/// </summary>
		/// <param name="decryptString">要解密的字符串</param>
		/// <param name="sKey">加密Key</param>
		/// <returns>正确返回加密后的结果，错误返回源字符串</returns>
		public static string ToDESDecrypt(string decryptString)
		{
			byte[] keyBytes = Encoding.UTF8.GetBytes(sKey);
			byte[] keyIV = keyBytes;
			byte[] inputByteArray = DecodeBase64(decryptString);
			DESCryptoServiceProvider desProvider = new DESCryptoServiceProvider();
			// java 默认的是ECB模式，PKCS5padding；c#默认的CBC模式，PKCS7padding 所以这里我们默认使用ECB方式
			desProvider.Mode = CipherMode.ECB;
			MemoryStream memStream = new MemoryStream();
			CryptoStream crypStream = new CryptoStream(memStream, desProvider.CreateDecryptor(keyBytes, keyIV), CryptoStreamMode.Write);
			crypStream.Write(inputByteArray, 0, inputByteArray.Length);
			crypStream.FlushFinalBlock();
			return Encoding.UTF8.GetString(memStream.ToArray());
		}

		internal static void ToDESEncrypt(object jsonConvert)
		{
			throw new NotImplementedException();
		}
	}
}
