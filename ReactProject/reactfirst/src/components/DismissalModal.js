import React, { Component } from 'react';

class DismissalModal extends Component {
  state = {
    reason: '',
  };

  handleReasonChange = (e) => {
    this.setState({
      reason: e.target.value,
    });
  };

  handleSubmit = (e) => {
    e.preventDefault();
    this.props.onDismiss(this.state.reason);
  };

  render() {
    return (
      <div className='modal'>
        <div className='modal-content'>
          <span className='close' onClick={this.props.onClose}>
            &times;
          </span>
          <h2>Причина увольнения</h2>
          <form onSubmit={this.handleSubmit}>
            <label>
              Причина:
              <textarea
                value={this.state.reason}
                onChange={this.handleReasonChange}
                required
              />
            </label>
            <button type='submit'>Отправить</button>
          </form>
        </div>
      </div>
    );
  }
}

export default DismissalModal;
