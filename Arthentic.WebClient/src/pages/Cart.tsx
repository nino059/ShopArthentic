const Cart = () => {
  return (
    <div className="container py-5">
      <h1 className="fw-bold mb-4">Giỏ hàng của bạn</h1>
      <div className="alert alert-info">
        Giỏ hàng hiện đang trống. <br />
        Bạn có thể thêm sản phẩm từ trang Cửa hàng.
      </div>
      {/* Sau này sẽ hiển thị danh sách sản phẩm trong giỏ */}
    </div>
  );
};

export default Cart;