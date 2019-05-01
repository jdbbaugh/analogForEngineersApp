using System;
using System.Collections.Generic;
using System.Text;
using analogCapstone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace analogCapstone.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
            public DbSet<ApplicationUser> ApplicationUsers { get; set; }
            public DbSet<Song> Song { get; set; }
            public DbSet<Channel> Channel { get; set; }
            public DbSet<ChannelToGear> ChannelToGear { get; set; }
            public DbSet<Gear> Gear { get; set; }
            public DbSet<Knob> Knob { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                //MAY NEEDidentity overide and such here

                //ask about this and what i can get away without
                ApplicationUser user = new ApplicationUser
                {
                    FirstName = "Kurt",
                    LastName = "Ballou",
                    UserName = "Kurt",
                    producerImgUrl = "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAkGBxMTEhUTExMVFhUXGBoZGBgYFRoZGhYaGBcYGh0WGBgYHSggGh0nHRcXITEhJSkrLi4uFx8zODMtNygtLisBCgoKDg0OGxAQGi0lICUtKy0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLf/AABEIAKkBKQMBIgACEQEDEQH/xAAcAAABBQEBAQAAAAAAAAAAAAAFAgMEBgcBAAj/xABQEAABAwIEAwUDBgkICAYDAAABAgMRAAQFEiExBkFREyJhcYEykbEHFEKhwdEVIzNSYnKCsvAkNFNzk6LC0hZDVGODkpTxFyV0w+Hio6Sz/8QAGQEAAwEBAQAAAAAAAAAAAAAAAAECAwQF/8QAKhEAAgIBBAIBAgYDAAAAAAAAAAECEQMSITFBBFETMnEiM0JhkaEjgfH/2gAMAwEAAhEDEQA/ADdVxX5d4fpD90VZBVdeEXD3mn90VyeV+WdOL6jhjP4xXXDXF9aaUur8P8szz/WeXTKqWtwU0VjrXSYiF0waeURUO9uktpKifIdTQwOXCwkSart1cFZhSoHJI1HrFIxzEjojnuqPqTPSoQfOUJTEnUn7Kh7mipHltlXJUDnH8RSFNxAHlHWnEOaQVknpyFSLZjJ+MISoERAVt506CyA9bFOp9Ip+0vijSJFKLsnf0NdftZTmChI5dPPTSgOSa1chXgadIoVbOdnBPsmiXbJIkGaaZLOKFIUmldoOtcUodaBDZFJIrqljrSe0HWmByuGnO7GZS0pGwKp1IjQAAk7j30jtGv6Zv3L/AMlTYUcr1OOoSiM7iE5hmE5jIkgEZUkQYpIea/pm/cv/ACUWh0xMUoClvBKfbWlGpAnMZymCe6k6TXGsqpyLSuIkDMDqYB7yRzIp6kFM8BTiU0hTzYJBeQCDB0Xy/Yp+ydbUtIC0ua6pBUCRzjMkT6UOaSsKOtpqTfp7qfKpfEmVDxkpQmEgTsdNgACenLnQ24xFlQA7ZGngv/LRDIpRTCUWnQ0E08gU27lRBWtKQfZJJObTcZQZGu9eRes/0yPcv7U1eqIUS0in01EfuENkBbiUkiQCFHQ7GUpIpTWJsbdsj3LH1lMUa0KmEm1VF4hd/EeopT9400YccSk9NSY6wkGoGKXrLyAht1BVOxCkz4AqSBNJyQ6Y7wtso+VH5qvcMuBOfMQPMxRr583+en3ivLzJubOzG1pQfTxex0WP2R99DHsaaU6tYJhWWNOgg1WmY1JEwJ92tWbCVsuMZ1J/GE6Jy9zLrJKt5mK9KeGMlTOWM2naG7vFW1IIBMyOVDxcjqatLmFtpjM2iCJB6+G2gqq4mylLkI0BGaJmCdwJ5UQ8eMFSG5tu2L7cHnSSqedR84Ak15t0GIEzt40/iXsWr9hxqFqCEmVHYTr7qZVh7hKSseyFOEeAOVM+utGsJs1KdSU6KByqjdAMhUk7HLOniKsOItJc7dIACkIcbH6ntj11TNGhFdGJuqzKJNKcSU6keHl4edWLhbhlV08Egae0AZAIHNShsBp51YLjgpttwBSgtR2HsoHpJMeJNRKSQRxtme21k4uSlJgak8hU4XASAlWU/q/aa1kNs27OVxsqaIIUQ3mE9SEgke6qBi+Csuuj5k07k+kpSVBA/VzAVMZ2VLHXBGwmwRcPtoSTC1BGYiACQT8AasV98mj6VFTbuYDlt6DlVhwHC20i1AiUFKj4qIH+GPfWgFAqZz7RUYJLcwG+4VuEpW4ppQSg66g7c4oLanTwr6KvLQLQpB2UCD6isFvbMtqWiNifqMH4UQnqFPGluiLSVCn0DQUllPeNaoxZGNdFSrpAA2qOrZNAhnFfYa/b+KafVgcobUhSQVJBVncSNwIyjeN+u1Ixsdxr9v4ppjE3UKSyUmVBsJUIOhT5jzpb9DH+IWigsJJBIYSJBkGFr2PMV1i0t1QEqUpWWSM5GoTKh+SjkedNYz7Nv/UJ/fXUm2VbohSVJCssSS5oVIhXdCI5nnU/pH2MY1K3GxzUkGPFxalD6lCvcP6OlJ3KSPVKkq/wmuYi5kupgK7NSBHIltKRH92vYM9N2hREZnCI6Z5TH96n+kXY002hVwUuHKgrVJmI9qNSDGsU7giQLpASZAWYPUAK191ItrYOXJQqQCpcxvpmOk+VP4ISi6CAdCpSD4jXf3CiXD+wLkL/ACjflkeR+CaEnBczbakKSCpMqzuJG8QUjeN+u1FvlG/LN+R/w1X8RdQpDOVUqS3lUIOkGRuPE+6s8F/HGisn1Mfx9ooDCSQSlqJBkHvr2PPeo+KWaWw1lJ77YUZI3PSBtS8XHctv6n/3HK9i9ylYaymcraQdCII5a/ZWkb2/2S+xWPbs/wDp2v3aaxizS0tITMFIOpB1lQ5AdKdx7dn/ANO1+7SccuErWkoMgIA2I1zKMajxFEeEDO48Px2uxQ0fMdkjb3GpLWENuSpp7uiO4QVODrIAAieY0p7EbloKyOJWvuoPIZcyEnuq3G+23hQl0pbdllZISQUrgg8jRHhIHQYuMPBWpWdUEk6I6k6amoHZUVv3kKecLqu9P0QCCBpy0B0FCsqa0SVBQbCoOwI5+Io9hmMstiCyYHs5V7A7jXfWq8w0J8zG/L/tR+6DdulLYaDijJklI003J8xWqEEE4+xmzBCxIggmR8aCYjdhxZUBA2SJJ0HMzzqdh5Q/LZZDasvtDKrwkRt69aDXdvDhTJ7qin6+fpTYCHn0pEqOnTmfuFD28eyrBSkAAjl08d6hYq+VKPQfxFQ2bdSjoJrJsRvPBTYcZbcIHeBWI6q0jwO59aYeslfPFJREfSPJSjBPn7MetSOAGz8yZWo95IIyndISooBA8wBPhRjAwFuuaQlBiZkqOm/TnVPg2SO4bgybVla20jOoEehI09wFZtxDd3BcJSQVDnpp4CtQ4yxpDFsrWVHQDnJ6Vi99iLhzKWgBM7EGVT0jesJ80jRPa2FsE4rdQoJcAP8AHSrdjDyltoW3JBB0CcxEgjkayzHbFdq42oKCm3U5kEE8jBGuuh+NaPwTiJdZj6STBH21lNaXTNIPUT8AslDsyoEZUiZ3Kuaj8AOQq1IIPOq7jTqUJGZeX4/VVXZxOXfxD5BnVKiQFeh51PI2aQ4KxnGGs1y7l1hxRH6qokeh1rS8PvHJKVgidj91Zc4rLe3CTulxUeIO491PGt2Z5OECbprIop6GozJ7xqbiXeUVHMTsYmJFDH8oBgkKrpSOaTJN4e7UZWyah9oTuTXifE0yQ5bWqHiG1iQJIMkEbSPGYFQHGGQSOyJ8e0M+mkfUaZw25KHEmdNjVo/0Lu12S8QSlHzcBSvbOfKlRSSE5YiQeewo0oLADzrTmQFs9xIQIc5Ak693xNNdizMdmr+0/wDrVqwH5Nr+5ZTcNhlKHAS2lx3KtwDmlMHSNdSPdTDPAt6plFwEIyqe+bhGY9oHO1LRBTEABQMmdhNTpodgTtEBwuBBCzmM9psVA6xHjXW1tqc7UoOfMFTn0zAzMR1p3iXBnLK4Nu8psuJAKg2sqCcwkJJIEKiDHRQ60SwXgu7fs3L5sI7FAcJlRCyGxKilOXXY8+Ro0oLBjaWkr7RKDm1MlcgFQI2jxrrJaS8lwIObPPt6ST0jbWvWtmt1xtlEZ3FpQmTAlRAEnkJNWXF/kvxFhCnVJZUlAlQbdzKSPziCkaAa6axScR2DONltl0BQC4GwJBQYGk+MDSq5DP8ARH+0M+mn2Gr5ffJLiaUKVlYWUjNlQ8StQ8ApIk+tQOHvk3vbtlFwjskoXJbS45lW6BzQnKdNOZHXbWljxqMVEJSt2Va4eSoJSpqUoEJ75BAmSCqNRPhUYqZH+pP9qf8ALWksfJNevNpWgNp3BStZSoKSSFSAk8waBn5M79Tlw2UtpNugLXmc0KVBRBQQDOiD0q69Csqj96heUrakpGUZVlIgEwIg7Ax6U52bMBQaJHi4frgCrG38m94tu1WhCFG6AU0Er1ylAXmckAIASddT0qc98mV+2Wmj2Ku2cKELQ7KAtKVqKVnLKTCFcjqCKVBZUbl9CzmcRKtpCinQbAiDsIHkBUdLzQMhrUajM4SPUQJ8pq74l8lOIN9mFG377iW0w6T3lTE9zbSouP8AyXYhasruFpaUhsSvs3MykgbqIKRoNzFFBZUA9mJJ3OvmTS4qM3vUqmIMtHX9ofUAPsqx4syVZFtJKwAoHKeuXx/RNVN19CNT/wB6l4bjRjK2sp8Nq1TXAFi4eYWXCtSVIRk3UYnUHSD4UKxGO2c1+mT6E0zeY4tKSFuEgiCNNfDaoTFyhyI3HKhtVQAy5tzmPnSrNSmVhyAQPq86J3TGbUb/ABqImNiPfUDNmwDGEptLfkt1pTio2CStRAM+KjR7AWFN2oUfacJWfU6TVZw3CVFu2eRBZ+bNJImCDly+upJrSLi1AbSOiQPdUpNp/c6pUq+xnGM2faElXM86GmwznvagQADsANqsONWxEq5UPaWCNdAOdcTuLo3pNFV4yZSpCEk5lJ9k/mjonzqz8D4T2LaST3ljN4RGn20HXhLt+4FtAC3SrLnJ9sg97KOfSavWgeKQMuVIAHTTarak1bEkrBfEViHANYM69SI2nl6VVbDCn/xueAACUSqQo6QnKf2tRrqOdaF2eanBbCKcJ0iJRtgLh1altgrEKTOnT1rK+KxF5ckb9qI1/RFbmm2CQYG9Y7iDRViTxTBl3LB2kaSfCYFGJ7sjLvQKdue6IKSs6KIkHzMEUzcYfOsz18aTflKXV5QNSecga6TTZf8AGt3ZySF4ewjL3hJn3U28tpKoIptLwTNQLhUmetaXsAVvrdIbK0jfbxr6Nw7AsjDNgpbfZfMVMuIKu+pawgFYT+bo5J6mvm+2cPZAiQUEKSZ2IMg+8U+vii9LwuzcuF9Kcgc0zBGvdGkR3jy50MDZuGrNxy2srK/tXULShSba6tnSC3kbiVLQQplRR3dZCoMjlR7g9DVpaJbed7TLevNpcXqVOLuHEpKj+cSognqa+fLfjzEm0qSi8eAWpSiJG6jKiNJTJJPdjUmoQ4ju+xFv26+xC+0CJ0C82fNO85jmmd6kApx9hbzGI3CHlFSitTmc/TSs5kr9xjTQFJHKt74Owg29rY2xU2Em3c7Zsqha1u5VkpTzglwHzr5vxjiC5ulBdw6XVAZQpUTlknLoBpJPvp97iy+cfbuFXK1PNAhtemZAIIITpGoJ99ABjCrZTWLW7Kplq8Q2Z55HgmfWJ9a07jzjO3srq7YbYcVdXKGkOOFQ7IJyFKSBMyErVpAk86w97GH1PfOFOKL2YL7TTNnEQraJ0HupWI4q9cO9s+4px0xK1RPd22HKgD6dulIOIuIaBTeGxBQ6qVNhHbLCUlsKEkL1npzoBhtuVHh1baVFtDK8ygCQkGxgZiNBJ0151io4xv8Atu3+du9rk7PP3ZyZs2TaIza0jDOKr23b7Ji6ebb17iVd0TvlB9j9mKAN9xF1x60d7DOpQv8AL3JJhF0ArbYCFTy3ml3BCr/E0p1V8xYEDef5VpHWFJ94rAcN4uvrdvsmbp1tEkwkjdRkmSCZJk0zacQ3bTpfbuFpeVOZzMSpU75iqc2w0M7DpQB9DcJdxnCUL7q/mZGVQhUhtiRB1BFVPhPCL5t63cduMtsb64CLZTcKzE3PfCiJ17yt9jWTXnEl468i4cunVPN+wvNBR+rlgCecDXnNPXXF9+4426u7dUtoktqkdwkZSQkDLMEiYnWgDWMasmvwww4jDrltwXiCu7UVllwFChCQVZRJKdh9E0R4rUhVrjibYFt1IHzhS+8lwfNkmEDN3D2fdmN+vLELvj/E1wFXjpyqChOXRSdQduVcRxVeLQ8Tcufyjuv7fjRlyDNp+b3dKAAzbZ6fXtTsGoDrhJ3Nc7dXU0AEcTaJM01hzCs4MEVPN2k8jXhepTyNVsOhvFGSTNMYQwrtAYIHjUsYkk6FJ91PDEEJEhJp7WIIFvpSEtmO8JPl91RvwoP6NZ8k138LaT2bg8xVWgNT4KxdK7ZNvqFtEQI0KCoHQ9QfjWnOOBTfjFYP8m+J9pdKREDIY6nUTsOnxrXfnuQGT6UjVO0RsebAaKjyrMOL7v8AEBtBMk6gbkdNK0vG30rZUZ0CfrrD8VvodIUIQJifpeINc+SNys2U6jRAOKXADaEvOIS3IQELyhMnMdj1Jq+WvETrjYLjqUPFEBZhZUQYCilMRpAPUis+byFQJ0E0SesYczJWFBSRljTXpFJ0SnJGr8IuPdme2dS6cxhYAGZJ2McqsmbSss4VxJ23cCHAcp+qtKZfCkgpOhrFqmbqVjzq9Kzy3wVyFvhJJJdXESSQoZQB1Jmrji94GmlLPIGPE1DtsVVassp+b3LyijMeyazAFRJIUradTV4k2zPI0uTJrng+/WoqFs7qfzY3259KjucF34SVG2cgCTIG3qa1pvHnc8jDr6FZcyi2ATCVCYmJ1T503jeJ3VwgpRh12CSjdKQO642szB3hJHurr0nJt7Mwb4LxGYNqowJ1UjQDxzRTx+T7EVESxE/pogeuatPTil4C4Bht2UrUpWvZBSQpMQBtoddaRfXuIOJhOG3CYU0Y7RGzbgX13IEUaQ/CZuPk7xKCA0IH+8R0nTWmMT4Petms10pLSdIP5TcxEIMg6j31rzWJ4lEDCnfCXmh79aCcZ4NiN+wUDDlNLlJkutHNCgY0OggUUFoyH5pb/wC1f/rr++u/NbX/AGpX/TK/z1Y//CnFf9mH9qj76T/4WYpsWEj/AIiaFFvom0V8W9pzuXfS3+9yuhmy/prj0YT9q6saPkmxM/6psebo+wU//wCEGJ/ms/2p/wAtGl+g1Iq8WP8ASXZ/4bQ+K6WvD2XG1uW7jhLYzLQ6lKVZZjOkpJBAJEjfWp/E/Ad3YNJdfDeVSggZVlRkgnUFI6GoXC3tXA62r3wSfspNDTAzqiK4m5POuqE1xbYqQHBcilB6mUtip1zYpShKgTJ3osCOHacBpgNjrFLaYGve+NAHXmgrz611CYEV1VsI0J+un1WbcSVkehNAEV5AVEgT1++k/NxTqmGv6U/2avvpHYt/0iv7M/fTGGxxTef7Qv3J/wAtXDhbCsRvLZL4xAoCyoZSgH2VEbx4VX/9GE/nK+qrbw3iTtowlhtoKSkqIUqZOYk8vOs45V2n/Bs8Mva/kpfEWK31pcuW5u1qyRJgAHMkK2jxoceLL2I+cuR+z91TOOldq+p8+2owtI2SUpAj3Cq0kVcZ2ZSjpdBscYX/APtTvvH3U3ccT3jqChy4cUkiCkkQR02oTkp22tVLVlQCo7wOnUnYDxOlOyS1/Jk+U3qDO4UNBJMjb+Ola3i64QTMHqeXnWV/JvhyRiVunPK8x9nVIhKjud/qHia1HiHuZ0k6iTOmo0299Ut0aR2AGL4ynsCie/ACjH8cvjVXuwkhJjXqQNRU3FWCEZhsqScx9YHTegDTwSrKqTGw+2sckTWMtw1ZYkynRwSOkAg+hona4bh72qW2wfAZD6RVPfbSo+1AJ5fCj+B4QkLCi5CSdjWXCNFkdhe9wDs0EoVKQfpalI/W5j66P4PcBDICtIqNjF0lLKgTAIiRVVfxv+TpE6nT6pmpSchOVMIcR4mpxxLaE5tZyzvA2+qithx7dlACWQnLpl7IgCBqASsT9tBOEcNW+8HARlAO5En03jXer2jAI0gcuQ5bV6njeOtFt0ed5MpSf4QI5xzfFtlSG0ZlE9qCgjIn6MAq1V1GtF7Xi55THaR34V3SMhJGwhR0nxqQnAB+aNug6z8daX+AvAc+Q5711LFBPdnO/kb3IOEcU3S1J7dtDY1mHAqCNhRW4x9X0HGx5kny2FIGCeXXlvXRg2s6f9qejGNawfiOOXBz9ncITKUhvu5oWSZKtNjpEeNR3sduENfzhTi5TJShI8DlB0idKM/gfbbT7K4cHp6cQSU3/wBEtY6SB3jMa9ZG+1L/AAurqr3Gmvwb3ssmYmfWnRhR/OPvq6x/sC10eGKK/S9xrqcTV+l7jzrowrxpQwodaX+MPxmffLPfZrRtJmS6CJnklU1m3Cf5V0dbd8f3J+ytJ+WqyyWjKtT+OH7i6zjgzW5jq08P/wASq4fIrXsdOO63ASFaCnHleFMo2FLcrlLOA0RunPxaaGJqY+4MqU0ARzT7FM+ldQr+JpgTU0q5Hd2qP2xAqaOJnAPYRUyclwi4KL+pi8MtgpGo5mpX4OHQUzbcQPK0S23O/Tbzr3+kz39Ej3GudrJfH9m3+L3/AEOX1kpDoSpTY11BXqQTuecxFaVwjgTirVs5k6ZhoSYE6cteVZljVqhSytbmVSoOo9rugjXl0rQuCMUcQyUI0TIUARJ1H/xXfG7aRghHyn4Jksu00lKxJAgnMCPurIEGtr46fW7h74J2AVt+aoGsTQaiaae4SHm0FRCUiSSAB1JMAVZcXCbZPzdJ9nRxQ3cWN/QGQB4Tzop8mnC/bK+eO6NNKlA/PcTqDP5qTHmfI1XseSVBSvpBf1GftrKXoqK2stPyIoLmKJOgShpxXqQEifHU+6tT40w/tUnLooajWJjr1rJfk5vk2b7Tp2/1nUhQg+4GfStfxq8TAcSoFB1BGoM04ZF0aaGqsyjELkZSy4DnSCmeuUEiOYkn6qbtmkOAlOiloI25oExB66VaL1lh5RmEuaaxvqd6qtzZLtoQSlElRz7xtqDrGgAgdT1rRNMzaor1wrKd+f1RrNEbfEDBM7bA/wAb1X8YKQruKOSTE7/xrTbV8EjafGs3FCUqDeMYw4pISomOlN4Yy48YSFKyAkwCYA8KDIlxYmdToNzWncO2ZsmwopzOKTmWnomQNfI0tkNW3YW4SxdCQlaEggCIhIPLcxPLnV3tsabVvKT76oGKYWWj85ZjKrVaEiARvnT4/Gp1pchaQRvGnjTXkTXYfHFmgN3KDspPvp6R1rOzmOxI6jnXbjFFMkd9QSfGrXle0S8K9mhyOtekdaoa+Jnkgd4FJ5lIn3iKLWPEJzZnEGCI7p0HjB++tV5MHyT8MiylQpOYUObWw8kJDqwdfpFKtfGiS7YTEmSOvSt1KL4Zm1XI0UpzZucR6UvMKbZtSHCfoxG/PyqXlptomxjMK9mHjT+WklNFoDOPluE4eD0eR8FCsn4IH8rbHVLg97S62D5ak/8AlxPRxv8Aej7ax/gj+eseKlD3tqrDLyjSHBX0bCplpYuPLDbSFLWeSRJgbmmUsGQmjfC9m8u6S3bOFDpCgFgkQANdRryrCihn/Re5BgtqB6QZ18Klp4XuDuy76INWHC7R1m4CC6y48lWozKWoqgiCfWd+VW44heoHeaRl2JB18wCf4mjgaRmJ4YeA/IPT1yH7qiXGBuo9pp0eaI2861VqxvM2ZN0lQUPpJ1TOxABgx5UP4mtnW2k9o8Xfa1iI7vWtMcFKVBJmWWdm4+ooZbW4qJhIkgbSaItcG3qgpQt1oA3ziNImahYBjlxaLUu3VlUpMKOUK0BnmOtGH/lExFSFILwhQIMNoBg76xWb5BUVtLBy55TAMRnEnyG8eNJ7XwFKD3dKYTG+u/TSo0UCLviN92QTnZS5MQoxlSoEjWfLnVi4SuVL7xATIPPTQjWR50k2T/YgrVYBskpC1XKtTzAIRr5VJwKzdU52TN1YKWROUFazlEctNK2VKVlB7GLbNbvI07zah70msb4e4ceunktBKkjQrWpJAbTzUZ5xsOdajjls4lITcOtPFJCkoZbUnUT7SysiNdqr9pxGv+UZiAQgIbQnZOY6nzgDUyayy5E2Xpsv2L2SLbDezYGVCW+712mSepJk+dYyp7RSd8wraMYvkfM25MpU2nx3ArJHsHUTmQef1GsZ1ZSI1lc6pHVPwosxjL7SShKzkP0TqPSdqC4jhbrKjPQKHkefvqVZHtB41hONO0bRnapjlzjTszMeXnPxqZa8VpWnJcIzDYKA1HnOvupy14cLm5ipjnBaI3NVDITKJSMTbQVnIqRy0A9NKk4Pw+pwgqUAPDU1bLfgdPUnxmjuDcOdkdYNauexkse57hnhxpsghEx9I6k1PurgB52dUpytHwlGeT4HNofDxFH7VpKEkmAAJJ5ADc1m91inbIvHW1ZQ6+2hv9IIA7w6d0E1lG5OzSVRQfw24cyKYOhb0TJ3Qek7/wDamcMWEkoBmDI/VnbXp8IoKzc+xnKidYUncJOgBG5BgnTaRFWBWBNXDQJAUDoqSdY2Kv410NbTSMUx1eM24IzXDAUOReQPtpu/u2LhOVD7K1DUJS6hRPiADNV7HOGWWWw6y2EqQqesjprRe1w9m4S24pIzoIKVDRQIM7jlptUUkNNsG2F8U/i1dat3adxBFUvHmC2vMNBNWfC387CT0ipaKTJ7yJSY33HnuKP8N45mSgLMhXsq6HpPSgTC9x5GhGB3MKLJOoUvL6KMU4ScXaCSUlTNbrmlDMFvw6kA+2B76JFqvRjJNWjjkmnR6kkildnSS341Wwii/LKmcMc8Ft//ANEisN4ZQFXbCFEhKnACQYOs863n5XGf/K3/AAyH3OJrBOHmgu6YSrZTqAY03UOdZ5ei4HLlGRRTHM6+tHfk+JTfNEA7KGg11SdpqPiWDrNxlBAClKCddsp291GuFcGWxdNuKUCBOg3MpI0rn1x9mlMs+HcGhu4+cl1WaVqCdIGaRqeehqTiJuXCQ0vuDRR1111A9KMFlbntnKn80bnzNSW0ZRA0HlVPdUJOitWvC30kvOoBG2aZka77UH43txZ26SnOsKVlOZU7pOv1VoFUT5XifmiOnaj901UZOLtAZMgkbUtsxEwRIkcyJ1HhV4TwZfItUqWlkNFOZRzArSkjMdMu4HjQW5NhKghp0gbEukFQ6lMGPKs07ZTjRMVaWJVIDGWNR87UNTEESnSNdPGufg2x/wB3/wBan/LQ21YtVaKS6kxP5QfanypjsLf813/nR91MRpeE8MpuLIpbum4DpczJSYSCjIURoQSddKk4RhTFjMLzu6wojVIIjKhMkxpzPqNqddube0R2NuACDqQNz1Ur6SvqFBbtZX3pJO81lkyrhG0YD2JXClDN7/Cq1dXCVodUkD2kpmN4GvxqwJEpynmI99Um2BQ242eTnwgVlzuPhmjtu5sNtieqh6BahQtkZVeBoklHZ4ewmR7JWSeRUpSo+AmqhfcUtN6Ilw+GiR+0d/Srabewm0i2Ynb52kuhRPZ+0CAcyFaEeX30M/AwbcQtvVtWqT/hPjTHDGN/OAsmEaZSkEkQeetTMKvlpZymFdmqIkagk7VbjcSVLcO2rUa1OZTNVC+4sNur8YwSg+ypKoI/RUlWx9YNca+Ulga9i6f+Qf4qz+J9GnyLsu6GYpx51DSS44tKEjcqMCs5xD5TnVCGWEI/SWc59wgfGqdiWKPXCszzilnlJ0HkkaD0qlifZLy+i48Z8d9uksW8ho6KXspzwA5J+s/GuYfcqUltobAq/wCZZ1PokfXQkCBNE8EtVFJIEmIGsaq3M+AmtVFJUZNthvCrztLxOhygDT9FP27VpaHEGNBm6xqB91ULhGwUla1qEx3dRqI1MH1q22g/GTETyrKbLihzFGApBT1FA8Gd7NWU7TFWS/MDNVecb1zVCZVEviOz7RokDlUHg24lCkGjlsoLbI8Kr2Etlq5UnlM++hPagrcs1gqZqqYhc9neKWdEo59c0K+2rS33XJ5H7aA8d2wDDyhy7NX94JP1RQgZcLC42Uk7woHzq3WF2HEzzGhHQ1nHClwVWzKj0j3VZ8Puuzck+yd/vrXDk0yp8EZI6kWia5Xgf4mvT/E16BylO+VlcYXcabhI8u+nWsAwFcXTB/3zf76a+gflYTOF3Hkk/wB4V89YUqHmj/vEfvprLL0XAmY8+sXDwzey85Gu0LUKJ8D3yhesKVK0yZTM6ZTqB4b+lB+JRF5cj/fOfvmpfAa1C/t8glUqgfsKmuVrk27NdvMWeQpybeUD8moLEr/W/NqB/pMsAFVq7zzZe8Exzkb1564u++sKbKTIQjKfxZB5n6dQxfXwA7jaiJk+wT0gHSatcCJbnGiB/qH40k5DGv8AHOqv8oXECLi3S2ErSQ4DChGkHeRvrR1WO3oEm0TGn0hPiCPuppjDncQuW2bu37NmFOSlUEwIyynxI91DY1G0yjXN88oJaTdOKSRlILhCYjnJimbsdmkJU3qoRIdSqY8AO7M860niLgfDrZlx38f3BOVK5JMwBKhWZqsg5BbVKuYV943pIGPufikyWVAkZZlChG86c/PShnd6O/3fuqY2pTYKT3HNPo7iZGo8ufWo8vdVU7JNCxBCVKUU7SY8pqK0ojSgmF4wUL7N3cGJo86jmK5WqZ0XsSEKqpvsy85GynCB5iJ+NWhk7VHs8PyLUowRnUpP7QTM+oNUkT2BL3FXG1pZX+TSBHjPP30IxTCSV5mhIVyHI1Z+IsNDicw9pO3iDyoJhFwQrIrlVpmb3BmEYgu0dzlB6KSZEjz61YBxLbklf4wSoEpidAD6TMURtwhZUlQBg7EeAqNdcPMnZMeRj6qer2GloIh+2vGihKwT02WPGDvB1qkYlhLjCsqxvqFDZXl91Lx3CTbqSUklKtUq5g8xIpyxxbMjsnypbc9ZUg/nIJ89tjTjtwD35ByRShUnELItAKBStCtEqTsT0I3SfA1GB5kR4VpZAl86UZ4dcKQSUlQgQARPtAxr1Aj1oFcqqycLQVokaJ1258vv9KmQ0aJhhDbXeBCiCTpoVE669JgelP27moNMXD8pShO0T6n/AOPiaWwNJrBmwRfTnBHWgl0ClJB3o0wZFQ8XZlBIpDIuFP6AUjE2YcS4PI1DtVwFdRyoo2vtEJ8wfTehoRIv38gbWdicp9dR9tAvlGf/AJOhsbuqSkeQUFfYKP4naduw40PaI7p6KSZH1igCbT5yLRxe7KlBYPXL96aqIpB3C2w2ylA+jHwoncL7k1X7G8C3XwNkZU+uk/x4UbUuWj5VLRSZZsCvwUhKjpGhPwowHU9U++qFgb+ZvyNP3vEDTSglzMCdjl0PrXZ42SLWmbowy43zFEz5UFJOGXMEHuTp5ivm+zVC0HopJ9yhW88Y4iwqwuE9q2SppQSAoKJVGggeNYOlhYBOUiI3EVvnhVUZ47C3FSR8/uJ27ZUxvBMn41I4MaCr9rs1Ze+oJJ3HdVE+YqPxkP5a+eqgfehNQ+G15blo/p/Ya5GuUa9mjJtnS6/D6u0OixI7oJ3A+j5+NO4hhziUt9hdqUMpK+0SPaP0QsHUb60PawwOPnUjtAQo5jrOuuuu1SXeEhGUOuJAnKArQT4GpUW6d8Dsj3DWIEJ/Go0iAOZHjznxoNxMb1oN9o+CVyr8WSlSI5EiOooq5wi4QP5SuUxHSR4VUMZcLby21uF0pPtSd+Y99U0xppJkjCw9cdoldw5lSgqVmdVqOneMHWKF2l2GwRG/Pn9dNpVpP2UQZKUiO0aM6wtgkgxtOv1UIls8QptMhSoXr01EEa896c/Ci/D/AJDQ9xWcwFIT4AFKBHPzNT/m36bH/UKoCyVxHZ5k9qjdPtDw6+lEeGMQ7RvKd06Up/2FeR/dNBeCPbV5Csq2KT3LglFPJNcRtS2agoj3I5UFv8PBVmGihRy43qIuqEV5q6KHjOkx8KsjK8wFVXFfy3oKsWGeyKGCH8RsQ60UHfdPgRt91Z6/bqTK0juyRtIBG/kNOdainlVKwf8Anq/67/3BV4yZgVhlYUjMkkGFJSZhQ6jqKsd7ZsL1KFsqI9pKZb9U8v2aIXuzX6zv71evvyA/Vpt0JFMxjD3GV5VjfVJGyh1B+yrTwKwVEqIBQnU+J5D+PGl8ffkGv6w/uUU4G/mZ/rB+7Q3sOK3C6zC/OiUAAiQNPjQ5/wBtNPn8q5/Uo/edrM0J9s6IEa151YIII0Pj/HSoKPup13f0NSxkG+b29wPM6iNvEj66j4Y4ZjbUjXwMH+PKiCvybf6yPimoCvyyf1l/AU+hFit/fQvEf5Kl9waoUFOAdFcx5az6miLFQ+Mf5i9+or900IGAuDATbuuE6rXJ+366tLS5ZJ8DVb4Q/mXqfjVhtfyB8jRIIjXCFzmQodCan47hKLppTS9DuhXNCuR8uooJwN9P9Y1ahvWctmaLgxtVutlamnU5XEGD0I5KHUHeaUSVkAmj/wAo386b/qh++qq+xuPOvd8abnBNhVHLq3GxJMHnQezOW4EbBYo7ee0fOq8x+W/a+2o8uKSRnlRdbjFg0QobgzTl9xYU3QRKSjs5IGvfPKaqWJ86Gj8v6/ZXBwmZLk0q34uaSAXgoidcg73oD99Q2RgTk964STJJWgkyeeaDrVRvt0+tR26iDbVsudJ0T8SsGc6y0VqZzEJVoFR1UOU1CYsc5CUZio7QJPnR+3/mrn6yPtpHDf8AOR5K+FUTQIcsuzzIzzHURBI109BzqP8ANR0+o0ZH84d/4vxqVTCj/9k=",
                    Email = "KBallou@GodCity.com",
                    NormalizedEmail = "KBALLOU@GODCITY.COM",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };
                var passwordHash = new PasswordHasher<ApplicationUser>();
                user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");

                ApplicationUser user2 = new ApplicationUser
                {
                    FirstName = "Joey",
                    LastName = "Baugh",
                    UserName = "Joey",
                    producerImgUrl = "https://i.pinimg.com/originals/3a/96/de/3a96de2e9c9321992a71814d31945399.jpg",
                    Email = "jbaugh@me.com",
                    NormalizedEmail = "JBAUGH@ME.COM",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };
                var passwordHash2 = new PasswordHasher<ApplicationUser>();
                user2.PasswordHash = passwordHash2.HashPassword(user2, "joey");

                modelBuilder.Entity<ApplicationUser>().HasData(user, user2);

                modelBuilder.Entity<Song>().HasData(
                    new Song()
                    {
                        SongId = 1,
                        ProducerId = user.Id,
                        BandArtistName = "Converge",
                        SongTitle = "Jane Doe"
                    },
                    new Song()
                    {
                        SongId = 2,
                        ProducerId = user2.Id,
                        BandArtistName = "Deft Prose",
                        SongTitle = "Guion"
                    }
                    
               );
                modelBuilder.Entity<Channel>().HasData(
                    new Channel()
                    {
                        ChannelId = 1,
                        ChannelName = "Ch1-Lead Vocal",
                        SongId = "1",
                    },
                    new Channel()
                    {
                        ChannelId = 2,
                        ChannelName = "Ch2-Elec-Gtr",
                        SongId = "1",
                    },
                    new Channel()
                    {
                        ChannelId = 3,
                        ChannelName = "Ch1-Acoustic Guitar",
                        SongId = "2",
                    },
                    new Channel()
                    {
                        ChannelId = 4,
                        ChannelName = "Ch2-Cow Bell",
                        SongId = "2",
                    }
               );

                modelBuilder.Entity<Gear>().HasData(
                    new Gear()
                    {
                        GearId = 1,
                        Make = "Chandler Limited",
                        Model = "TG2 Abbey Road Pre",
                        Type = "Pre-amplifier",
                        OrdinalsAvailable = 6,
                    },
                    new Gear()
                    {
                        GearId = 2,
                        Make = "Universal Audio",
                        Model = "LA-2A",
                        Type = "Limiter/Compressor",
                        OrdinalsAvailable = 2,
                    },
                    new Gear()
                    {
                        GearId = 3,
                        Make = "BAE",
                        Model = "1073",
                        Type = "Equalizer",
                        OrdinalsAvailable = 7,
                    },
                new Gear()
                    {
                        GearId = 4,
                        Make = "BAE",
                        Model = "1023",
                        Type = "Equalizer",
                        OrdinalsAvailable = 7,
                    },
                    new Gear()
                    {
                        GearId = 5,
                        Make = "Purple Audio",
                        Model = "MC-77",
                        Type = "Limiter/Compressor",
                        OrdinalsAvailable = 5,
                    }
                );




            }
    }
}
