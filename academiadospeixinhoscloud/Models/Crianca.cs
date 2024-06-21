using academiadospeixinhoscloud.Services;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace academiadospeixinhoscloud.Models
{
    public class Crianca
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
        public string? NIS
        {
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

        private string? _SeguroSaude;
        public string? SeguroSaude {
            get
            {
                // Decrypt the email when accessing it
                return _SeguroSaude != null ? EncryptionHelper.Decrypt(_SeguroSaude) : null;
            }
            set
            {
                // Encrypt the email when setting it
                _SeguroSaude = value != null ? EncryptionHelper.Encrypt(value) : null;
            }
        }

        private string? _Apolice;
        public string? Apolice {
            get
            {
                // Decrypt the email when accessing it
                return _Apolice != null ? EncryptionHelper.Decrypt(_Apolice) : null;
            }
            set
            {
                // Encrypt the email when setting it
                _Apolice = value != null ? EncryptionHelper.Encrypt(value) : null;
            }
        }

        private string? _Seguradora;
        public string? Seguradora {
            get
            {
                // Decrypt the email when accessing it
                return _Seguradora != null ? EncryptionHelper.Decrypt(_Seguradora) : null;
            }
            set
            {
                // Encrypt the email when setting it
                _Seguradora = value != null ? EncryptionHelper.Encrypt(value) : null;
            }
        }

        private string? _MoradaFiscal;
        public string? MoradaFiscal
        {
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

        private string? _Nacionalidade;
        public string? Nacionalidade {
            get
            {
                // Decrypt the email when accessing it
                return _Nacionalidade != null ? EncryptionHelper.Decrypt(_Nacionalidade) : null;
            }
            set
            {
                // Encrypt the email when setting it
                _Nacionalidade = value != null ? EncryptionHelper.Encrypt(value) : null;
            }
        }
        public int? QuantidadeAgregado { get; set; }

        private string? _Autorizados;
        public string? Autorizados {
            get
            {
                // Decrypt the email when accessing it
                return _Autorizados != null ? EncryptionHelper.Decrypt(_Autorizados) : null;
            }
            set
            {
                // Encrypt the email when setting it
                _Autorizados = value != null ? EncryptionHelper.Encrypt(value) : null;
            }
        }

        private string? _Doencas;
        public string? Doencas {
            get
            {
                // Decrypt the email when accessing it
                return _Doencas != null ? EncryptionHelper.Decrypt(_Doencas) : null;
            }
            set
            {
                // Encrypt the email when setting it
                _Doencas = value != null ? EncryptionHelper.Encrypt(value) : null;
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

        // Navigation property for many-to-many relationship

        public List<string?> NomesAtividades { get; set; }
        public ICollection<Atividade> Atividades { get; } = new List<Atividade>();

        public List<string?> NomesPais { get; set; }
        public ICollection<Pai> Pais { get; } = new List<Pai>();

        public List<string?> NomesSubscricao { get; set; }
        public ICollection<Subscricao> Subscricaoes { get; } = new List<Subscricao>();

        public List<string?> NomesProduto { get; set; }
        public ICollection<Produto> Produtos { get; } = new List<Produto>();
    }
}
