create table State(
    StateId varchar(2) primary key,
    StateName varchar(100)
);

create table Dist(
    DistId varchar(3) primary key,
    DistName varchar(100),
    Stateid varchar(2) 
);

alter table Dist add FOREIGN KEY (StateId) REFERENCES State(StateId);

-- may12
create table ZipCode(
    ZCode varchar(6) not null,
    DistId varchar(5) not null,
    AreaName varchar(100)
)
alter table ZipCode add foreign key(DistId) REFERENCES Dist(DistId)

INSERT INTO ZipCode VALUES
('732101', 'D-179', 'English Bazar'),
('732128', 'D-179', 'Old Malda'),
('732201', 'D-179', 'Kaliachak'),
('732123', 'D-179', 'Chanchal'),
('732125', 'D-179', 'Harishchandrapur'),
('732202', 'D-179', 'Manikchak'),
('732124', 'D-179', 'Gajol'),
('732147', 'D-179', 'Bamangola'),
('732210', 'D-179', 'Baishnabnagar'),
('732103', 'D-179', 'Rajbati Ramnagar'),
('732207', 'D-179', 'Mothabari'),
('732139', 'D-179', 'Samsi'),
('732211', 'D-179', 'Milki'),
('732138', 'D-179', 'Pakuahat'),
('732216', 'D-179', 'Mahadipur'),
('732142', 'D-179', 'Mangalbari'),
('732212', 'D-179', 'Jadupur'),
('732204', 'D-179', 'Paranpur'),
('732213', 'D-179', 'Pukhuria'),
('732215', 'D-179', 'Pubarun'),
('732141', 'D-179', 'Narayanpur'),
('732208', 'D-179', 'Niamatpur'),
('732140', 'D-179', 'Bhatolchandipur'),
('732126', 'D-179', 'Naikanda'),
('732123', 'D-179', 'Ismailpur'),
('732125', 'D-179', 'Malior'),
('732101', 'D-179', 'Netaji Subhas Road'),
('732128', 'D-179', 'Balia Nawabganj'),
('732123', 'D-179', 'Jagannathpur'),
('732124', 'D-179', 'Katna'),
('732123', 'D-179', 'Mallikpara'),
('732124', 'D-179', 'Hatimari'),
('732124', 'D-179', 'Katikandar'),
('732124', 'D-179', 'Shivajinagar'),
('732124', 'D-179', 'Mayna');
INSERT INTO ZipCode (ZCode, DistCode, AreaName) VALUES
('736121', 'D-167', 'Alipurduar Court'),
('736123', 'D-167', 'Kalchini'),
('736204', 'D-167', 'Falakata'),
('722101', 'D-168', 'Bankura'),
('722137', 'D-168', 'Khatra'),
('722140', 'D-168', 'Indpur'),
('731101', 'D-169', 'Suri'),
('731204', 'D-169', 'Bolpur'),
('731233', 'D-169', 'Rampurhat'),
('736101', 'D-170', 'Cooch Behar'),
('736131', 'D-170', 'Dinhata'),
('736169', 'D-170', 'Mathabhanga'),
('733101', 'D-171', 'Balurghat'),
('733121', 'D-171', 'Gangarampur'),
('733124', 'D-171', 'Tapan'),
('734101', 'D-172', 'Darjeeling'),
('734003', 'D-172', 'Siliguri'),
('734201', 'D-172', 'Kurseong'),
('712101', 'D-173', 'Chinsurah'),
('712136', 'D-173', 'Arambagh'),
('712201', 'D-173', 'Bandel'),
('711101', 'D-174', 'Howrah'),
('711204', 'D-174', 'Uluberia'),
('711302', 'D-174', 'Bagnan'),
('735101', 'D-175', 'Jalpaiguri'),
('735221', 'D-175', 'Maynaguri'),
('735231', 'D-175', 'Dhupguri'),
('721507', 'D-176', 'Jhargram'),
('721514', 'D-176', 'Gopiballavpur'),
('721505', 'D-176', 'Binpur'),
('734301', 'D-177', 'Kalimpong'),
('734314', 'D-177', 'Pedong'),
('734316', 'D-177', 'Gorubathan'),
('700001', 'D-178', 'BBD Bagh'),
('700019', 'D-178', 'Ballygunge'),
('700091', 'D-178', 'Salt Lake'),
('742101', 'D-180', 'Berhampore'),
('742123', 'D-180', 'Lalgola'),
('742189', 'D-180', 'Domkal');






create table Usr(
    UserId varchar(13) PRIMARY KEY,
    UserName varchar(100) not null,
    UserZipCode varchar(6) not null,
    UserProfileImage varbinary(max) not null,
    UserPassword binary(64) not null
)
alter table Usr add FOREIGN KEY (UserZipCode) REFERENCES ZipCode(ZCode) ON DELETE CASCADE;


create table Temp(
    Email varchar(100),
    Gkey numeric,
    Situation numeric
)

create table RCV(
    vehicleId int PRIMARY KEY,
    vehicleType varchar(100) not null,
    vehicleModelNumber varchar(100) not null,
    vehicleChassisNumber varchar(100) not null,
    vehicleEngineNumber varchar(100) not null,
    vehicleRegistrationNumber varchar(100) not null,
    vehicleFuelType varchar(10) not null,
    vehicleCapacity varchar(100) not null,
    vehicleYearOfManufacture DATE not null,
    vehicleRC varbinary(max) not null,
    vehicleInsurance varbinary(max) not null,
    vehicleFitnessCertificate varbinary(max) not null,
)