import { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { paintingService } from '../services/paintingService';
import type { Painting } from '../types/painting';

const ProductDetail = () => {
  const { id } = useParams<{ id: string }>();
  const navigate = useNavigate();
  const [painting, setPainting] = useState<Painting | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string>('');

  useEffect(() => {
    if (!id) return;

    const fetchDetail = async () => {
      try {
        setLoading(true);
        const data = await paintingService.getById(id);
        setPainting(data);
      } catch (err: unknown) {
        console.error(err);
        setError('Không tìm thấy tranh hoặc lỗi kết nối server');
      } finally {
        setLoading(false);
      }
    };

    fetchDetail();
  }, [id]);

  if (loading) return <div className="text-center py-20">Đang tải chi tiết tranh...</div>;
  if (error || !painting) return <div className="text-center py-20 text-red-500">{error || 'Không tìm thấy tranh'}</div>;

  return (
    <div className="max-w-6xl mx-auto px-4 py-10">
      <button 
        onClick={() => navigate(-1)}
        className="mb-6 text-blue-600 hover:text-blue-800 flex items-center gap-2"
      >
        ← Quay lại
      </button>

      <div className="grid grid-cols-1 lg:grid-cols-2 gap-10">
        {/* Hình ảnh */}
        <div>
          <img 
            src={painting.mainImageUrl} 
            alt={painting.title}
            className="w-full rounded-3xl shadow-xl"
          />
        </div>

        {/* Thông tin chi tiết */}
        <div className="space-y-6">
          <h1 className="text-4xl font-bold">{painting.title}</h1>
          <p className="text-lg text-gray-600">{painting.artistName}</p>

          <div className="flex items-baseline gap-3">
            {painting.discountPrice ? (
              <>
                <span className="text-5xl font-bold text-red-600">
                  {painting.discountPrice.toLocaleString('vi-VN')} ₫
                </span>
                <span className="text-2xl line-through text-gray-400">
                  {painting.price.toLocaleString('vi-VN')} ₫
                </span>
              </>
            ) : (
              <span className="text-5xl font-bold">
                {painting.price.toLocaleString('vi-VN')} ₫
              </span>
            )}
          </div>

          <div className="border-t border-b py-6 text-gray-700 leading-relaxed">
            {painting.description}
          </div>

          <div className="grid grid-cols-2 gap-4 text-sm">
            <div>
              <span className="font-medium">Kích thước:</span> {painting.width} × {painting.height} cm
            </div>
            <div>
              <span className="font-medium">Chất liệu:</span> {painting.medium}
            </div>
            <div>
              <span className="font-medium">Năm sáng tác:</span> {painting.yearCreated}
            </div>
            <div>
              <span className="font-medium">Tình trạng:</span> {painting.isAvailable ? 'Còn hàng' : 'Hết hàng'}
            </div>
          </div>

          <div className="flex gap-4 mt-8">
            <button 
              className="flex-1 bg-black text-white py-4 rounded-2xl text-lg font-medium hover:bg-gray-800 transition"
              onClick={() => alert('Đã thêm vào giỏ hàng! (Chức năng giỏ hàng sẽ làm sau)')}
            >
              Thêm vào giỏ hàng
            </button>
            
            <button 
              className="flex-1 bg-red-600 text-white py-4 rounded-2xl text-lg font-medium hover:bg-red-700 transition"
              onClick={() => alert('Chuyển sang trang thanh toán (sẽ làm sau)')}
            >
              Đặt hàng ngay
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default ProductDetail;