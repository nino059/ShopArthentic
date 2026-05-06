import { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { paintingService } from '../services/paintingService';
import type { Painting } from '../types/painting';

const Shop = () => {
  const [paintings, setPaintings] = useState<Painting[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const loadPaintings = async () => {
      try {
        setLoading(true);
        setError(null);
        const response = await paintingService.getAll(1, 16);
        const data = Array.isArray(response) ? response : response.items || [];
        setPaintings(data);
      } catch (err: unknown) {
        console.error(err);
        setError('Không thể tải danh sách tranh. Vui lòng thử lại sau.');
      } finally {
        setLoading(false);
      }
    };

    loadPaintings();
  }, []);

  if (loading) return <div className="flex justify-center items-center min-h-screen"><p className="text-xl">Đang tải...</p></div>;
  if (error) return <div className="text-center text-red-500 py-20 text-lg">{error}</div>;

  return (
    <div className="max-w-7xl mx-auto px-6 py-12">
      <h1 className="text-4xl font-bold text-center mb-4">Bộ Sưu Tập Tranh</h1>
      <p className="text-center text-gray-600 mb-12">Khám phá những tác phẩm nghệ thuật độc đáo</p>

      <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 gap-8">
        {paintings.map((painting) => (
          <Link
            key={painting.id}
            to={`/product/${painting.id}`}
            className="bg-white border border-gray-200 rounded-3xl overflow-hidden hover:shadow-2xl transition-all group block"
          >
            <div className="relative h-64">
              <img
                src={painting.mainImageUrl || 'https://picsum.photos/400/300'}
                alt={painting.title}
                className="w-full h-full object-cover group-hover:scale-105 transition-transform duration-300"
              />
              {painting.discountPrice && (
                <div className="absolute top-4 right-4 bg-red-500 text-white text-xs px-4 py-1.5 rounded-2xl font-medium">
                  SALE
                </div>
              )}
            </div>

            <div className="p-6">
              <h3 className="font-semibold text-lg line-clamp-2 mb-1 group-hover:text-blue-600 transition">
                {painting.title}
              </h3>
              <p className="text-sm text-gray-500 mb-4">{painting.artistName || 'Nghệ sĩ'}</p>

              <div className="flex justify-between items-end">
                <div>
                  {painting.discountPrice ? (
                    <>
                      <span className="text-2xl font-bold text-red-600">
                        {painting.discountPrice.toLocaleString('vi-VN')} ₫
                      </span>
                      <span className="text-sm line-through text-gray-400 block">
                        {painting.price.toLocaleString('vi-VN')} ₫
                      </span>
                    </>
                  ) : (
                    <span className="text-2xl font-bold text-gray-900">
                      {painting.price.toLocaleString('vi-VN')} ₫
                    </span>
                  )}
                </div>

                <button
                  onClick={(e) => {
                    e.preventDefault();        // Ngăn chuyển trang khi click nút
                    e.stopPropagation();
                    alert(`✅ Đã thêm "${painting.title}" vào giỏ hàng!`);
                    // Sau này thay bằng logic giỏ hàng thật
                  }}
                  className="bg-black text-white px-6 py-3 rounded-2xl text-sm hover:bg-gray-800 transition"
                >
                  Thêm giỏ
                </button>
              </div>
            </div>
          </Link>
        ))}
      </div>
    </div>
  );
};

export default Shop;