using academiadospeixinhoscloud.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace academiadospeixinhoscloud.Models
{
    public class Pai
    {
        public int Id { get; set; }

        private string? _Nome;
        public string? Nome
        {
            get
            {
                // Decrypt the email when accessing it
                return _Nome != null ? EncryptionHelper.Decrypt(_Nome) : null;
            }
            set
            {
                // Encrypt the email when setting it
                _Nome = value != null ? EncryptionHelper.Encrypt(value) : null;
            }
        }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        private string? _NIS;
        public string? NIS {
            get
            {
                // Decrypt the email when accessing it
                return _NIS != null ? EncryptionHelper.Decrypt(_NIS) : null;
            }
            set
            {
                // Encrypt the email when setting it
                _NIS = value != null ? EncryptionHelper.Encrypt(value) : null;
            }
        }

        private string? _NumeroUtente;
        public string? NumeroUtente
        {
            get
            {
                // Decrypt the email when accessing it
                return _NumeroUtente != null ? EncryptionHelper.Decrypt(_NumeroUtente) : null;
            }
            set
            {
                // Encrypt the email when setting it
                _NumeroUtente = value != null ? EncryptionHelper.Encrypt(value) : null;
            }
        }

        private string? _MoradaFiscal;
        public string? MoradaFiscal {
            get
            {
                // Decrypt the email when accessing it
                return _MoradaFiscal != null ? EncryptionHelper.Decrypt(_MoradaFiscal) : null;
            }
            set
            {
                // Encrypt the email when setting it
                _MoradaFiscal = value != null ? EncryptionHelper.Encrypt(value) : null;
            }
        }

        private string? _NBI;
        public string? NBI {
            get
            {
                // Decrypt the email when accessing it
                return _NBI != null ? EncryptionHelper.Decrypt(_NBI) : null;
            }
            set
            {
                // Encrypt the email when setting it
                _NBI = value != null ? EncryptionHelper.Encrypt(value) : null;
            }
        }

        [DataType(DataType.Date)]
        public DateTime ValidadeBI { get; set; }

        private string? _email;

        public string? Email
        {
            get
            {
                // Decrypt the email when accessing it
                return _email != null ? EncryptionHelper.Decrypt(_email) : null;
            }
            set
            {
                // Encrypt the email when setting it
                _email = value != null ? EncryptionHelper.Encrypt(value) : null;
            }
        }

        private string? _Telefone1;
        public string? Telefone1 {
            get
            {
                // Decrypt the email when accessing it
                return _Telefone1 != null ? EncryptionHelper.Decrypt(_Telefone1) : null;
            }
            set
            {
                // Encrypt the email when setting it
                _Telefone1 = value != null ? EncryptionHelper.Encrypt(value) : null;
            }
        }

        private string? _Telefone2;
        public string? Telefone2 {
            get
            {
                // Decrypt the email when accessing it
                return _Telefone2 != null ? EncryptionHelper.Decrypt(_Telefone2) : null;
            }
            set
            {
                // Encrypt the email when setting it
                _Telefone2 = value != null ? EncryptionHelper.Encrypt(value) : null;
            }
        }

        // Navigation property for many-to-many relationship

        public List<string?> NomesCriancas { get; set; }
        public ICollection<Crianca> Criancas { get; } = new List<Crianca>();

        public static implicit operator Pai(SelectList v)
        {
            throw new NotImplementedException();
        }
    }
}
