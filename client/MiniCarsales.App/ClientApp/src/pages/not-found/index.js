import React, { memo } from 'react';
import { Link } from 'react-router-dom';
import { Alert } from 'reactstrap';

export default memo(() => {
  return <Alert color="warning">page not found...<Link to="/" className="badge">go back</Link></Alert>;
});