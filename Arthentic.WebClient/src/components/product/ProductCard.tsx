import { Heart } from 'lucide-react';
import { Link } from 'react-router-dom';

interface ProductCardProps {
  id: string;
  title: string;
  price: number;
  discountPrice?: number;
  imageUrl: string;
  artistName: string;
}

const ProductCard = ({ id, title, price, discountPrice, imageUrl, artistName }: ProductCardProps) => {
  return (
    <div className="card h-100 shadow-sm border-0 hover-shadow transition-all">
      <Link to={`/product/${id}`} className="text-decoration-none">
        <img 
          src={imageUrl} 
          className="card-img-top" 
          alt={title}
          style={{ height: '240px', objectFit: 'cover' }}
        />
      </Link>
      <div className="card-body d-flex flex-column">
        <Link to={`/product/${id}`} className="text-decoration-none">
          <h5 className="card-title text-dark">{title}</h5>
        </Link>
        <p className="card-text text-muted small mb-3">{artistName}</p>
        
        <div className="mt-auto d-flex justify-content-between align-items-end">
          <div>
            {discountPrice ? (
              <>
                <span className="fs-4 fw-bold text-danger">
                  {discountPrice.toLocaleString('vi-VN')} ₫
                </span>
                <span className="text-muted text-decoration-line-through ms-2">
                  {price.toLocaleString('vi-VN')} ₫
                </span>
              </>
            ) : (
              <span className="fs-4 fw-bold text-dark">
                {price.toLocaleString('vi-VN')} ₫
              </span>
            )}
          </div>
          <button className="btn btn-outline-dark btn-sm">
            <Heart size={18} />
          </button>
        </div>
      </div>
    </div>
  );
};

export default ProductCard;