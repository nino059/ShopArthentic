const Artists = () => {
  const artists = [
    { id: 1, name: "Nguyễn Thanh Tùng", specialty: "Tranh phong cảnh", image: "https://picsum.photos/id/64/300/300" },
    { id: 2, name: "Trần Thị Lan", specialty: "Tranh chân dung", image: "https://picsum.photos/id/201/300/300" },
    { id: 3, name: "Lê Minh Quân", specialty: "Tranh trừu tượng", image: "https://picsum.photos/id/870/300/300" },
  ];

  return (
    <div className="container py-5">
      <h1 className="fw-bold mb-4">Các họa sĩ</h1>
      <div className="row g-4">
        {artists.map(artist => (
          <div key={artist.id} className="col-md-4">
            <div className="card h-100 shadow-sm">
              <img src={artist.image} className="card-img-top" alt={artist.name} />
              <div className="card-body text-center">
                <h5 className="card-title">{artist.name}</h5>
                <p className="card-text text-muted">{artist.specialty}</p>
              </div>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};

export default Artists;