﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace analogCapstone.Migrations
{
    public partial class withGearImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    producerImgUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gear",
                columns: table => new
                {
                    GearId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GearImage = table.Column<string>(nullable: true),
                    Make = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    OrdinalsAvailable = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gear", x => x.GearId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    SongId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SongTitle = table.Column<string>(nullable: false),
                    BandArtistName = table.Column<string>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.SongId);
                    table.ForeignKey(
                        name: "FK_Song_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Knob",
                columns: table => new
                {
                    KnobId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KnobName = table.Column<string>(nullable: true),
                    GearId = table.Column<int>(nullable: false),
                    Ordinal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knob", x => x.KnobId);
                    table.ForeignKey(
                        name: "FK_Knob_Gear_GearId",
                        column: x => x.GearId,
                        principalTable: "Gear",
                        principalColumn: "GearId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Channel",
                columns: table => new
                {
                    ChannelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChannelName = table.Column<string>(nullable: false),
                    SongId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channel", x => x.ChannelId);
                    table.ForeignKey(
                        name: "FK_Channel_Song_SongId",
                        column: x => x.SongId,
                        principalTable: "Song",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChannelToGear",
                columns: table => new
                {
                    ChannelToGearId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KnobSetting = table.Column<string>(nullable: false),
                    GearId = table.Column<int>(nullable: false),
                    ChannelId = table.Column<int>(nullable: false),
                    KnobId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelToGear", x => x.ChannelToGearId);
                    table.ForeignKey(
                        name: "FK_ChannelToGear_Channel_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "Channel",
                        principalColumn: "ChannelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChannelToGear_Gear_GearId",
                        column: x => x.GearId,
                        principalTable: "Gear",
                        principalColumn: "GearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChannelToGear_Knob_KnobId",
                        column: x => x.KnobId,
                        principalTable: "Knob",
                        principalColumn: "KnobId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "producerImgUrl" },
                values: new object[,]
                {
                    { "af071b0e-c1a4-4305-a0e2-5b414a4ad8d6", 0, "154b470a-75b1-48b9-9fff-c94a75401ef7", "KBallou@GodCity.com", true, "Kurt", "Ballou", false, null, "KBALLOU@GODCITY.COM", "KBALLOU@GODCITY.COM", "AQAAAAEAACcQAAAAEOV1OcZUsoUbFGSiveizWbBumG3+Ie0aAfVWggmAWN4RigSnx942fdw4GsYRP+8Dew==", null, false, "8c5d418b-97dd-4bb4-9e3b-a5d63214a3a4", false, "KBallou@GodCity.com", "https://i.ytimg.com/vi/5TQev-4g1sg/maxresdefault.jpg" },
                    { "ebb598b2-6c32-46b9-be1d-b49e8e853de0", 0, "dddf2a94-dab2-4f64-98e7-2655196bc9ce", "jbaugh@me.com", true, "Joey", "Baugh", false, null, "JBAUGH@ME.COM", "JBAUGH@ME.COM", "AQAAAAEAACcQAAAAEE5zRUzlrn0iqhj8ApeMT+PwkM6Cj8A+V7G0TeBXYSNJQqui0k1ZafrUtVyHVxlXlw==", null, false, "d3bc1248-296c-4872-9b90-4d7062957489", false, "jbaugh@me.com", "https://i.pinimg.com/originals/3a/96/de/3a96de2e9c9321992a71814d31945399.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Gear",
                columns: new[] { "GearId", "GearImage", "Make", "Model", "OrdinalsAvailable", "Type" },
                values: new object[,]
                {
                    { 1, "https://media.sweetwater.com/api/i/b-original__w-300__h-300__bg-ffffff__q-85__ha-149aaeef883ced21__hmac-c7d5de6f18a9a67d38f8d8f90d76deaead78b013/images/items/350/TG2.jpg", "Chandler Limited", "TG2 Abbey Road Pre", 6, "Pre-amplifier" },
                    { 2, "https://media.sweetwater.com/api/i/f-webp__b-original__w-300__h-300__bg-ffffff__q-85__ha-e5de4bf9fdd31c98__hmac-9278a44f7d5de43174182864ac3ebf0cf1c12e45/images/items/350/LA2A.jpg.auto.webp", "Universal Audio", "LA-2A", 2, "Limiter/Compressor" },
                    { 3, "data:image/jpeg;base64,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", "BAE", "1073", 7, "Equalizer" },
                    { 4, "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAkGBw0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ8NDQ0NFREWFhYRExUYHTQgGBslHRMTIT0tJS43Li4uFx8/RDQsNygtLysBCgoKDg0OGhAQGy0lHRktLS0tKysrLSsuLSsrLS0tLSs3Ny0tLSstLS0rKy0tKystLSs3LS0tKzctLS0tKy0rK//AABEIAOEA4QMBIgACEQEDEQH/xAAcAAEBAAICAwAAAAAAAAAAAAAAAQcIAgYDBAX/xAA9EAACAgECAwUECQIEBwEAAAAAAQIDBAUREiExBxNBlNEGFlFVFCIyU2FxgZGTFyMkQ1LSMzRCVGSh4RX/xAAWAQEBAQAAAAAAAAAAAAAAAAAAAQL/xAAaEQEBAQEBAQEAAAAAAAAAAAAAEQECMSES/9oADAMBAAIRAxEAPwDOBSACggAoIAKAAAIUAAABCkAAAAAAAKQAAAAAAoIAKCACgAAAAAIUCFIUAAAAAAAAAAQAUEAAFAEAAoIAAAApAABQAAAAAACAoAEBQIUACAoAgKAICgCAAACgCAFAgKQACgCAoAgKQACgAAAABAKAAAAAAAAAAAIUAQoAAAAAAIUgAoAAhQAAAAAAAAAAAAAAAAAAAAEKABCgAAQAUACAFAAACFAAAAAAAAAAAAAAAAAAAAACACggApCkAoAAAhQBAAKAQAUhQAIAKAAAAA+fqWtYWG4rLy8fGc03BX3Qqc0urXE+fVHpr2w0j5ngfpl0+p0Tta9oLdL1TTMqmum2ccTLhwXxc4bSnDdrZpp8uv5/ExVquTk6nkZGc6qoOxqU4UpV1raKjtBN7vkt3+pKsbIe+GkfM8HzVXqPfDSPmWD5mr1NXN14OXRbp7cn47HJSFI2h98NI+ZYXma/Ue+OkfMsLzFfqawKR7dOOpVd931EY7tcMptWbp7fZS/EUjZP3x0j5lheYh6j3x0j5lh/zw9TWru4/fV/tb/tLGEfvq/2t/2ikbK++Ok/McP+eHqT3x0n5jh/zw9TDGJpmhSwe9s1aEMzuJTWP3lXO7gbUOFriX1to/Hmde0evHsyaYZVyox5ykrLXKMFBcLae8uS5pLn8RUbFR9r9Kb2WoYjfPkrot/E4++WkfMsP+eHqYV1bRdMduLRp2pRybcluDUZV2wrsfBwxnKD3inxS57P7PTbmfPjqXs7XkLEshqFtcZquzUo21whxcWznGjbfu+vjxbC6rPcvbDSVtvqOIt0mt7ordPxQftfpKSb1DESlvs3dHZ89uRg1+zkIajdi35EI1YsbLsm2uMlXCiMXZvWm25Lh2f67b9G+Gk6joeoXwwK6M7Dcn3eNlZGXC2MrH0VtfDtXxPlvFvZteBLqzGdPfLSPmWH/PD1OfvZpf8A3+N0T/4sej6MwVpmm4tMMy/NsbxsOv8AxCrhGV3eOajXXS9/tSclzeyWz332Z7GnarpWqxuqxabsLLpx7JUxybY31X1Qju0pRScZxSbXJ7pNeO6XSM1y9r9JXJ6hiJ/jdFBe1+ktNrUMRqO3E++jsvz+BgPVNHuqhhWTf9rJhJU2TlDnwzbk2lJ7bca/M82sZui6XdLAyMfOzL4qCy7KcqNFdNjSfBCLj/ccd+r2W/ghdSM6e+ej/MsP+eHqT310b5nheYh6mBNV07Honx0ZLniXY8MipuMe8sobUuCSf2JeHR80/Dc6vna3CUXXXXGMO87zaKa2l9bx359dttuiXw3F1ZjaT300f5nhfzw9R756P8yw/wCeHqa3XzUq6XCX9tR+qnOMpptvfdJJrpt+n4nlw8CVtV9qclGhKU2ocUVF/F7ipGxnvno/zLC/nh6j300f5nheYh6msjZ4rpqK3lNRXPbxb2Xw8Obiufx5b7MUjZ/300f5nheYh6j310b5nheYh6mr6fwkpJ81KL3TXx/D9eZ5sap2TjBJtvfZKXD0W/N7fgx+ljZr310b5nheYh6nt6b7Rafl2OnFzMe+1Rc3XVbGc1BNJy2XhzX7mstKyMG2jKUYcVNtdtamlZByXNcS+HIyX2b+1OTq+vd9kxphOvTL6oqiDhHh76p89223+ozrN8Oud5+azGADTLDXbdpmTm6hp1GJTZfc8TJn3da3lwqyO759FzX7mMbndhTljZOO4X483tCzeMqpSjvzS68mn+xszq3s3TlZNOY7sqjIoqsphZjWqv8AtzacoyWz35pfsddzuyjS8m2d99mfbdY+Kdk8rinJ7bc3w/BJfoSLWvO/N79XzZzRn59kGjvbd5r2Wy3yd9l8FyC7H9F/8vzP/wAEKwE2e1LOrePGhYOJG5RjB5qjP6RKuMuLbZy4U3yXElu0upnVdkOi/DL8y/Qq7ItFX/RleZkIVgJMM2AXZNov3eR5mZX2T6J91keZsJCsT4+X7NfQeGePkf8A6P0Xbj4b+F5nB9pNWcO3Fz+ztsfG0mzChkVvPhOzF2n3kYKTe/A+HlGSf2uHozN67JNE691keZsOT7JtFfWrI8zMQrE+ra5pNGRi2aJXl0wqlKy6qcpxV1qceCMuKb5Nd4nt4PofMu0bRpXu6WXkV0yt3sxPo7d1c5c/oytT7v8A1fW35Jc+Zmd9kGhv/KyPNWFXZFoig6+7yeByUmvpVn2ktupcNjE1PtFK3ULZ2022V3Rsrvwp28MK6O77twhPfbfhb5tLaSjz23Gk6do+FdVmUX5WbbCSsxsW7FVEe+2c63fbxuMox+q2q023FfHYyt/R7QvusnzVhzl2RaG4xi68nhjxbL6TZ49efj0GYu7jEeBrNORXlUZjvtxcuC7/AGmu+x7IuMoW18T4ZSUoOW31U1KS68KOWDh6dpjtvxb7s3LlRbXU/o0sSvGjKCjZcuOTlObjNqPCuFcfNtLcyx/R7QvusnzVvqc7eyPRJ8PFXkvgjGEf8VZyiuiE+G7lYWyfaS7IVFd9rdGHGxUOFThdNTSUoSfHvzXLfd/k92j39Y0/S9RvnmZV+RhZU4xeVVXi/SarLVwJ20yUlwcSa+rYls5eKMtf0j0P7rI8zYSHZHokVOKryUppKS+lWc0nv+nNEzNN3GHtVy6bW6qa5UY0MeEIQlKU1GiMfqXWTh9Vz4ot8k0+8aT6HWKtDcnvJ8mlLaPC4yTb+txb7Jdf0W/Lc2GXY/oa32rylv12y7Vv+fMv9IdE/wBGX04f+cu+z8OvQsKwPe+77un7qLXWfFu5NvdSS4evgvE5VXRUbU995w4YNQjLbrvu2+Xh8f8A0jO8eyHQ10qyPNWM5/0n0X7vI8zMkK1/T+J4b6PpC4XOEe7e0e8s4VtLm+T/ABS6bdX18Nhn2TaL93keZmeF9j2hP/KyfN2+pcxGvrkoy4FtwR5RSk5Rit29k3+Z5qMidclKt8MuaT4VLry6NGfF2O6F91k+bt9TnHsj0SPSGUvDll2rkTcq5s8YQllW5brxsel95dY1wKXeyutnKO23Evqc14Pbmd97KdCzdO11VZtEqJ2afkzgpShJSirKk2nFtHdK+ybRoSjOEcqE4SUozjl2xlGSe6aae6Z9zTPZPFxstZqtzLsiNMqIzysu3I4apNNxSm+XOKGc5ni71u+6++ADTCAFAAEAAFAAACFAAAAAAAAAAAAAAAAAAAAAAAAAAAACIpCgAAAAAEKABCgAAAAAAAAAAAAAAAAAAAAAAAAAAABCgAAABCgAACAUAAACAUAAAAAAAAAAAAAAAAAAAABCgAQpCgAABAABQQoAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIBQQAUAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACFDAgKAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA/9k=", "BAE", "1023", 7, "Equalizer" },
                    { 5, "https://media.sweetwater.com/api/i/b-original__w-300__h-300__bg-ffffff__q-85__ha-6b3f35df45b88803__hmac-07960099bd7ef3468bb2ec90f3da3418b2d74dc0/images/items/350/MC77.jpg", "Purple Audio", "MC-77", 5, "Limiter/Compressor" }
                });

            migrationBuilder.InsertData(
                table: "Knob",
                columns: new[] { "KnobId", "GearId", "KnobName", "Ordinal" },
                values: new object[,]
                {
                    { 13, 3, "Volume", 5 },
                    { 25, 5, "Attack", 3 },
                    { 24, 5, "Output", 2 },
                    { 23, 5, "Input", 1 },
                    { 22, 4, "Output", 7 },
                    { 21, 4, "Ohm", 6 },
                    { 20, 4, "Volume", 5 },
                    { 19, 4, "LoPass", 4 },
                    { 18, 4, "MidEq", 3 },
                    { 17, 4, "LoEq", 2 },
                    { 16, 4, "HiPass", 1 },
                    { 15, 3, "Output", 7 },
                    { 14, 3, "Ohm", 6 },
                    { 26, 5, "Release", 4 },
                    { 27, 5, "Ratio", 5 },
                    { 11, 3, "MidEq", 3 },
                    { 10, 3, "LoEq", 2 },
                    { 9, 3, "HiPass", 1 },
                    { 8, 2, "Peak Reduction", 2 },
                    { 7, 2, "Gain", 1 },
                    { 6, 1, "300Ohm", 6 },
                    { 5, 1, "48v", 5 },
                    { 4, 1, "DI", 4 },
                    { 3, 1, "Phase", 3 },
                    { 2, 1, "Output", 2 },
                    { 1, 1, "Input", 1 },
                    { 12, 3, "LoPass", 4 }
                });

            migrationBuilder.InsertData(
                table: "Song",
                columns: new[] { "SongId", "ApplicationUserId", "BandArtistName", "SongTitle" },
                values: new object[,]
                {
                    { 2, "ebb598b2-6c32-46b9-be1d-b49e8e853de0", "Deft Prose", "Guion" },
                    { 1, "af071b0e-c1a4-4305-a0e2-5b414a4ad8d6", "Converge", "Jane Doe" }
                });

            migrationBuilder.InsertData(
                table: "Channel",
                columns: new[] { "ChannelId", "ChannelName", "SongId" },
                values: new object[,]
                {
                    { 1, "Ch1-Lead Vocal", 1 },
                    { 2, "Ch2-Elec-Gtr", 1 },
                    { 3, "Ch1-Acoustic Guitar", 2 },
                    { 4, "Ch2-Cow Bell", 2 }
                });

            migrationBuilder.InsertData(
                table: "ChannelToGear",
                columns: new[] { "ChannelToGearId", "ChannelId", "GearId", "KnobId", "KnobSetting" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, "35" },
                    { 20, 3, 4, 20, "Mic+30" },
                    { 21, 3, 4, 21, "1200" },
                    { 22, 3, 4, 22, ".75" },
                    { 23, 3, 2, 7, "27" },
                    { 24, 3, 2, 8, "47" },
                    { 25, 4, 1, 1, "25" },
                    { 19, 3, 4, 19, "10k@+2.5" },
                    { 26, 4, 1, 2, "4" },
                    { 28, 4, 1, 4, "On" },
                    { 29, 4, 1, 5, "Off" },
                    { 30, 4, 1, 6, "Off" },
                    { 31, 4, 5, 23, "33" },
                    { 32, 4, 5, 24, "21" },
                    { 33, 4, 5, 25, "3.75" },
                    { 27, 4, 1, 3, "Off" },
                    { 34, 4, 5, 26, "6" },
                    { 18, 3, 4, 18, "2k2@-3" },
                    { 16, 3, 4, 16, "220" },
                    { 2, 1, 1, 2, "6.5" },
                    { 3, 1, 1, 3, "Off" },
                    { 4, 1, 1, 4, "Off" },
                    { 5, 1, 1, 5, "Off" },
                    { 6, 1, 1, 6, "Off" },
                    { 7, 1, 2, 7, "42" },
                    { 17, 3, 4, 17, "400@+1" },
                    { 8, 1, 2, 8, "37" },
                    { 10, 2, 3, 19, "220@+2" },
                    { 11, 2, 3, 11, "1k8@-1" },
                    { 12, 2, 3, 12, "+1" },
                    { 13, 2, 3, 13, "Mic+25" },
                    { 14, 2, 3, 14, "1200" },
                    { 15, 2, 3, 15, "Full" },
                    { 9, 2, 3, 9, "80" },
                    { 35, 4, 5, 27, "8" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Channel_SongId",
                table: "Channel",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_ChannelToGear_ChannelId",
                table: "ChannelToGear",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_ChannelToGear_GearId",
                table: "ChannelToGear",
                column: "GearId");

            migrationBuilder.CreateIndex(
                name: "IX_ChannelToGear_KnobId",
                table: "ChannelToGear",
                column: "KnobId");

            migrationBuilder.CreateIndex(
                name: "IX_Knob_GearId",
                table: "Knob",
                column: "GearId");

            migrationBuilder.CreateIndex(
                name: "IX_Song_ApplicationUserId",
                table: "Song",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ChannelToGear");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Channel");

            migrationBuilder.DropTable(
                name: "Knob");

            migrationBuilder.DropTable(
                name: "Song");

            migrationBuilder.DropTable(
                name: "Gear");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
