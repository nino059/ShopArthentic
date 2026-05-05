import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { paintingService } from '../services/paintingService';
import type { Painting } from '../types/Painting'; 

const ProductDetail = () => {
  const { id } = useParams<{ id: string }>();
  const [painting, setPainting] = useState<Painting | null>(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    if (!id) return;
    const fetchDetail = async () => {
      try {
        const data = await paintingService.getById(id);
        setPainting(data);
      } catch (error) {
        console.error(error);
      } finally {
        setLoading(false);
      }
    };
    fetchDetail();
  }, [id]);

  if (loading) return <div className="container py-5">Đang tải...</div>;
  if (!painting) return <div className="container py-5">Không tìm thấy tranh</div>;

  return (
    <div className="container py-5">
      <div className="row">
        <div className="col-lg-6">
          <img 
            src={painting.imageUrl || 'https://picsum.photos/id/1015/800/800'} 
            className="img-fluid rounded-3 shadow" 
            alt={painting.title}
          />
        </div>
        <div className="col-lg-6">
          <h1 className="fw-bold">{painting.title}</h1>
          <p className="text-muted fs-5">{painting.artistName}</p>
          <h3 className="text-primary fw-bold">{painting.price.toLocaleString('vi-VN')} ₫</h3>
          <button className="btn btn-dark btn-lg px-5 mt-4">Thêm vào giỏ hàng</button>
        </div>
      </div>
    </div>
  );
};

export default ProductDetail;