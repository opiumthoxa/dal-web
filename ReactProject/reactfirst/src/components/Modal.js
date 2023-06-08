import React, { Component } from 'react';

class Modal extends Component {
  state = {
    reason: ''
  };

  handleInputChange = (event) => {
    this.setState({ reason: event.target.value });
  };

  handleSubmit = (event) => {
    event.preventDefault();
    this.props.onSubmit(this.state.reason);
    this.setState({ reason: '' });
    this.props.onClose();
  };

  render() {
    const { isOpen, onClose } = this.props;

    return (
      <>
        {isOpen && (
          <div className='modal'>
            <div className='modal-content'>
            <button className="modal-close-btn" onClick={onClose}>×</button>
              <h2>Причина увольнения</h2>
              <form onSubmit={this.handleSubmit}>
                <label>
                  Причина:
                  <input
                    type='text'
                    value={this.state.reason}
                    onChange={this.handleInputChange}
                    placeholder='Введите причину увольнения'
                    required
                  />
                </label>
                <br />
                <button type='submit'>Отправить</button>
              </form>
            </div>
          </div>
        )}
      </>
    );
  }
}

export default Modal;
