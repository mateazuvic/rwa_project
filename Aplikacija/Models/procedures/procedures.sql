use AdventureWorksOBP
go

create proc GetRacuniKupca
	@idKupac int
as
begin
	select * from Racun as r
	inner join Kupac as k
	on r.KupacID=k.IDKupac
	where k.IDKupac=@idKupac
end
go

create proc DeleteKupac
	@idKupac int
as
begin
	delete from Stavka
	where RacunID IN (
		select IDRacun from Racun
		where KupacID = @idKupac
	)

	delete from Racun
	where KupacID = @idKupac

	delete from Kupac
	where IDKupac = @idKupac
end
go

create procedure GetKupac
	@idKupac int
as
begin
	select * from Kupac where IDKupac=@idKupac
end
go

alter proc UpdateKupac
	@idKupac int,
	@ime nvarchar(50),
	@prezime nvarchar(50),
	@email nvarchar(50),
	@telefon nvarchar(25),
	@gradID int
as
begin
	update Kupac set Ime=@ime, Prezime=@prezime, Email=@email, Telefon=@telefon, GradID=@gradID	where IDKupac=@idKupac 
end
go

create proc GetGrad
	@gradId int
as
begin
	select * from Grad
	where IDGrad=@gradId
end
go

create proc GetKupci
as
begin
	select * from Kupac join Grad on Kupac.GradID=Grad.IDGrad
end
go

create proc GetKupciFromCountry
	@idDrzava int
as
begin
	select * from Kupac as k
	inner join Grad as g
	on k.GradID=g.IDGrad
	inner join Drzava as d
	on g.DrzavaID=d.IDDrzava
	where IDDrzava=@idDrzava
end
go

alter proc GetProizvodi
as
begin
	select * from Proizvod as p
	join Potkategorija as pk on p.PotkategorijaID=pk.IDPotkategorija
	join Kategorija as k on pk.KategorijaID=k.IDKategorija
end
go

create proc GetProizvod
	@id int
as
begin
	select * from Proizvod where IDProizvod=@id
end
go

create proc UpdateProizvod
	@id int,
	@naziv nvarchar(50),
	@broj nvarchar(25),
	@boja nvarchar(15),
	@minKol smallint,
	@cijena money,
	@potkID int
as
begin
	update Proizvod set Naziv=@naziv, BrojProizvoda=@broj,Boja=@boja,MinimalnaKolicinaNaSkladistu=@minKol,CijenaBezPDV=@cijena,PotkategorijaID=@potkID 
	where IDProizvod=@id
end
go

create proc UpdatePotk
	@id int,
	@naziv nvarchar(50),
	@kategorijaID int
as
begin
	update Potkategorija set Naziv=@naziv,KategorijaID = @kategorijaID
	where IDPotkategorija=@id
end
go

create proc UpdateKat
	@id int,
	@naziv nvarchar(50)
as
begin
	update Kategorija set Naziv=@naziv
	where IDKategorija=@id
end
go

create proc GetPotk
	@id int
as
begin
	select * from Potkategorija where IDPotkategorija=@id
end
go

alter proc GetPotkategorije
as
begin
	select p.IDPotkategorija, p.KategorijaID, p.Naziv, k.IDKategorija, k.Naziv as Kat from Potkategorija as p
	join Kategorija as k
	on p.KategorijaID=k.IDKategorija
end
go

create proc GetProductsCount
as
begin
	select count(*) from Proizvod
end
go

create proc GetPotkCount
as
begin
	select count(*) from Potkategorija
end
go


create proc GetKategorije
as
begin
	select * from Kategorija
end
go

create proc GetKat
	@id int
as
begin
	select * from Kategorija
	where IDKategorija=@id
end
go

create proc GetKatCount
as
begin
	select count(*) from Kategorija
end
go

alter proc DeletePotk
	@id int
as
begin
	delete from Stavka 
	where ProizvodID IN (
		select IDProizvod
		from Proizvod as p inner join Potkategorija as pt
		on p.PotkategorijaID=pt.IDPotkategorija
		where pt.IDPotkategorija=@id
	)

	delete from Proizvod
	where PotkategorijaID IN (
		select IDPotkategorija from Potkategorija
		where IDPotkategorija=@id
	)

	delete from Potkategorija
	where IDPotkategorija=@id
end
go

create proc DeleteProizvod
	@id int
as
begin
	delete from Stavka 
	where ProizvodID IN (
		select IDProizvod
		from Proizvod as p 
		where p.IDProizvod=@id
	)

	delete from Proizvod
	where IDProizvod=@id
	

end
go

create proc DeleteKategorija
	@id int
as
begin
	delete from Stavka 
	where ProizvodID IN (
		select IDProizvod
		from Proizvod as p inner join Potkategorija as pt
		on p.PotkategorijaID=pt.IDPotkategorija
		where pt.KategorijaID=@id
	)

	delete from Proizvod
	where PotkategorijaID IN (
		select IDPotkategorija from Potkategorija
		where KategorijaID=@id
	)

	delete from Potkategorija
	where KategorijaID=@id

	delete from Kategorija
	where IDKategorija=@id
end
go

create proc CreateKat
	@naziv nvarchar(50)
as
begin
	insert into Kategorija(Naziv) values (@naziv)
end
go

create proc CreatePotkat
	@naziv nvarchar(50),
	@katId int
as
begin
	insert into Potkategorija(KategorijaID, Naziv) values (@katId, @naziv)
end
go

create proc CreateProizvod
	@naziv nvarchar(50),
	@broj nvarchar(25),
	@boja nvarchar(15),
	@min smallint,
	@cijena money,
	@potkId int
as
begin
	insert into Proizvod(Naziv, BrojProizvoda, Boja, MinimalnaKolicinaNaSkladistu, CijenaBezPDV, PotkategorijaID)
	values (@naziv, @broj, @boja, @min, @cijena, @potkId)
end
go

create proc GetGradovi
as
begin
	select * from Grad
end
go

create proc GetPotks
as
begin
	select * from Potkategorija
end
go